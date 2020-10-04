using Cinemachine;
using Tools.StateManager;
using UnityEngine;

namespace LD47.States
{
	public class MovementState : PlayerState
	{
		private bool IsGrounded => Physics.Raycast(player.transform.position, Vector3.down, player.DistanceToGround + 0.1f);

		private float xRotation = 0.0f;
		private Transform cameraTransform = null;

		public MovementState(PlayerController player) : base(player)
		{
			cameraTransform = player.GetComponentInChildren<CinemachineVirtualCamera>().transform;
		}

		public override bool CanEnter(StateBase currentState)
		{
			return currentState == null;
		}

		public override bool CanExit()
		{
			return false;
		}

		public override void OnEnterState()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		public override void OnExitState()
		{
			Debug.Log("Byew");
		}

		public override void Update()
		{
			Rotate();
			Walk();
		}

		public override void FixedUpdate()
		{
			player.Playerbody.angularVelocity = Vector3.zero;

			if (Input.GetAxis("Jump") > 0 && IsGrounded)
			{
				player.Playerbody.AddForce(Vector3.up * player.JumpForce, ForceMode.Impulse);
			}
		}

		private void Rotate()
		{
			player.transform.Rotate(Vector3.up * (player.LookSpeed * Input.GetAxis("Mouse X") * Time.deltaTime));

			xRotation -= Input.GetAxis("Mouse Y") * player.LookSpeed * Time.deltaTime;
			xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
			cameraTransform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
		}

		private void Walk()
		{
			Vector3 movement = player.transform.right * Input.GetAxis("Horizontal") + player.transform.forward * Input.GetAxis("Vertical");
			player.Playerbody.position += movement * player.MovementSpeed * Time.deltaTime;
		}
	}
}