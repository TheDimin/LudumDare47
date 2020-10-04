using LD47;
using UnityEngine;

public class LavaPit : MonoBehaviour
{
	private void OnTriggerEnter(Collider collider)
	{
		if(collider.GetComponent<Pickupable>() != null) Destroy(collider.gameObject);
	}
}