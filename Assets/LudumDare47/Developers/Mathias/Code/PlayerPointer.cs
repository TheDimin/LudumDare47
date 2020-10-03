using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPointer : MonoBehaviour
{
	[SerializeField] private float reach;

	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			Debug.DrawRay(transform.position, transform.forward, Color.blue, 2.0f);

			if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, reach))
			{
				Debug.Log($"You hit: {raycastHit.collider.name}");
			}
		}
	}

}