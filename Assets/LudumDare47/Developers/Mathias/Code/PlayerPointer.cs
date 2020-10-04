using UnityEngine;

namespace ld47
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
					Debug.Log($"You hit: {raycastHit.collider.name}");
					//TODO: Check if the hit object is interactible, if yes send message that the plyer starts interacting with it.
				}
			}
		}
	}
}