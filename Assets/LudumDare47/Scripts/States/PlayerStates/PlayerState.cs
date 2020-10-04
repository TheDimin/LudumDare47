using Tools.StateManager;

namespace LD47.States
{
	public abstract class PlayerState : StateBase
	{
		protected PlayerController player = null;

		public PlayerState(PlayerController player)
		{
			this.player = player;
		}
	}
}