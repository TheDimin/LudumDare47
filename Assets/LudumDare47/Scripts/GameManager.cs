using JimTheKiwifruit;
using Tools.StateManager;
using UnityEngine;

namespace LD47
{
	public class GameManager : Singleton<GameManager>
	{
		public StateManagerBase<StateBase> StateManager { get; private set; } = new StateManagerBase<StateBase>();

		protected override void Awake()
		{
			base.Awake();
		}

		private void Update()
		{
			//StateManager.Update();
		}
	}
}