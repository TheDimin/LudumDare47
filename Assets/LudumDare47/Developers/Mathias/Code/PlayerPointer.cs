using LD47.Interfaces;
using UnityEngine;

namespace LD47
{
	public class PlayerPointer : MonoBehaviour
	{
		[SerializeField] private float reach;

		private void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, reach))
				{
					if (raycastHit.collider.GetComponent<IInteractible>() == null)
					{
						return;
					}

					raycastHit.collider.gameObject.SendMessage("OnInteract", transform.parent.gameObject);
				}
			}
		}
	}
}