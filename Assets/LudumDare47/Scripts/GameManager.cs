using JimTheKiwifruit;
using Tools.StateManager;
using UnityEngine;

namespace ld47
{
	public class GameManager : Singleton<GameManager>
	{
		public enum MouseVisibility
		{
			Hidden,
			Visible
		};

		public MouseVisibility CurrentMouseVisibility { get; private set; } = MouseVisibility.Hidden;

		public StateManagerBase<StateBase> StateManager { get; private set; } = new StateManagerBase<StateBase>();

		protected override void Awake()
		{
			base.Awake();
		}

		private void Update()
		{
			//StateManager.Update();

			if (Input.GetKeyDown(KeyCode.Escape)) SetMouseVisability(MouseVisibility.Visible);
			if (Input.GetMouseButtonDown(0)) SetMouseVisability(MouseVisibility.Hidden); //TODO: Check for UI state.
		}

		public void SetMouseVisability(MouseVisibility mouseVisibility)
		{
			switch (mouseVisibility)
			{
				case MouseVisibility.Hidden:
					CurrentMouseVisibility = MouseVisibility.Hidden;
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
					break;

				case MouseVisibility.Visible:
					CurrentMouseVisibility = MouseVisibility.Visible;
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					break;
			}
		}
	}
}