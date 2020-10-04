using LD47.Interfaces;
using UnityEngine;

namespace LD47
{
	[RequireComponent(typeof(Rigidbody))]
	public class Pickupable : MonoBehaviour, IPickupable
	{
		private Rigidbody rbody = null;
		private Collider collider = null;

		private void Start()
		{
			collider = GetComponent<Collider>();
			rbody = GetComponent<Rigidbody>();
		}

		public void OnInteract(GameObject interactingObject)
		{
			var playerController = interactingObject.GetComponent<PlayerController>();
			
			if (playerController.PickedupObject != null) return;
			
			playerController.AttachPickedupObject(this);

			var carrier = interactingObject.transform.Find("{PickupCarrier}");
			if (carrier == null)
			{
				Debug.LogError("The " + interactingObject.name + "should have {PickupCarrier} as a child");
				return;
			}

			if (ConveyorBelt.Instance.speed != 0)
			{
				return;
			}

			Hold(carrier);
		}

		public void Hold(Transform carrier)
		{
			transform.SetParent(carrier);
			transform.localScale = Vector3.one;
			transform.localPosition = Vector3.zero;
			collider.enabled = false;
			rbody.isKinematic = true;
		}

		public void OnRelease(GameObject carrier)
		{
			carrier.GetComponent<PlayerController>().DettachPickedupObject();

			OnRelease();
		}

		public void OnRelease()
		{
			transform.parent = null;
			transform.localScale = Vector3.one;
			collider.enabled = true;
			rbody.isKinematic = false;
		}
	}
}