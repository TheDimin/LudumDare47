using Cinemachine;
using Tools.StateManager;
using UnityEngine;

namespace ld47
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour
	{
		
		private StateManagerBase<PlayerState> stateManager = new StateManagerBase<PlayerState>();

		[SerializeField] float movementSpeed;
		public float MovementSpeed => movementSpeed;
		[SerializeField] private float lookSpeed;
		public float LookSpeed => lookSpeed;
		[SerializeField] private float jumpForce;
		public float JumpForce => jumpForce;

		private bool canMove = true;
		public Rigidbody Playerbody { get; private set; } = null;
		private Collider playerCollider = null;
		public float DistanceToGround { get; private set; } = 0;

		private void Awake()
		{
			Playerbody = GetComponent<Rigidbody>();
			playerCollider = GetComponent<Collider>();
			DistanceToGround = playerCollider.bounds.extents.y;

			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

			stateManager.RegisterState(new MovementState(this));
		}

		private void Update()
		{
			stateManager.Update();
		}

		private void FixedUpdate()
		{
			stateManager.FixedUpdate();
		}	

		public void ToggleMove(bool active) => canMove = active;
	}
}