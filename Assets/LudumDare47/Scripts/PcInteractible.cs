using UnityEngine;
using LD47.Interfaces;
using LD47.Minigame;

namespace LD47
{
	public class PcInteractible : MonoBehaviour, IInteractible
	{
		public void OnInteract(GameObject interactingObject)
		{
			PCPlayState.isInteractedWith = true;
			Debug.Log("Start Minigame");
		}
	}
}