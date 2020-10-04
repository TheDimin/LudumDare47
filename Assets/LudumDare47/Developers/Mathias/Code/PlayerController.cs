﻿using Tools.StateManager;
using LD47.States;
using UnityEngine;

namespace LD47
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerController : MonoBehaviour
	{
		private StateManagerBase<PlayerState> stateManager = new StateManagerBase<PlayerState>();

		public Pickupable PickedupObject { get; private set; }
		[SerializeField] float movementSpeed;
		public float MovementSpeed => movementSpeed;
		[SerializeField] private float lookSpeed;
		public float LookSpeed => lookSpeed;
		[SerializeField] private float jumpForce;
		public float JumpForce => jumpForce;

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

			if (Input.GetKeyDown(KeyCode.R) && PickedupObject != null) PickedupObject.OnRelease(gameObject);
		}

		private void FixedUpdate()
		{
			stateManager.FixedUpdate();
		}
		
		public void AttachPickedupObject(Pickupable pickedupObject) => PickedupObject = pickedupObject;
		public void DettachPickedupObject() => PickedupObject = null;
	}
}