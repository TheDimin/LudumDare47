using UnityEngine;
using LD47.Interfaces;

namespace LD47
{
	public class Interactible : MonoBehaviour, IInteractible
	{
		public void OnInteract(GameObject interactingObject)
		{
			Debug.Log("Start minigame");
			//TODO: enter minigame state and lockplayer state.
		}
	}
}