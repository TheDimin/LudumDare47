using UnityEngine;

namespace LD47.Interfaces
{
	public interface IPickupable : IInteractible
	{
		void Hold(Transform carrier);
		void OnRelease();
	}
}