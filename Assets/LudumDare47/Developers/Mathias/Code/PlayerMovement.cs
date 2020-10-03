using Cinemachine;
using UnityEngine;

namespace ld47
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour
	{
		private bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.1f);

		[SerializeField] float movementSpeed;
		[SerializeField] private float lookSpeed;
		[SerializeField] private float jumpForce;

		private Rigidbody playerbody = null;
		private Collider playerCollider = null;
		private Transform cameraTransform = null;
		private float distanceToGround = 0;
		private float xRotation = 0.0f;

		private void Awake()
		{
			playerbody = GetComponent<Rigidbody>();
			playerCollider = GetComponent<Collider>();
			cameraTransform = GetComponentInChildren<CinemachineVirtualCamera>().transform;
			distanceToGround = playerCollider.bounds.extents.y;

			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void Update()
		{
			Rotate();
			Walk();
		}

		private void FixedUpdate()
		{
			Jump();
		}

		private void Rotate()
		{
			if (GameManager.Instance.CurrentMouseVisibility != GameManager.MouseVisibility.Hidden)
			{
				return;
			}

			transform.Rotate(Vector3.up * lookSpeed * Input.GetAxis("Mouse X") * Time.deltaTime);

			xRotation -= Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
			xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
			cameraTransform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
		}

		private void Walk()
		{
			Vector3 movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
			transform.position += movement * movementSpeed * Time.deltaTime;
		}

		private void Jump()
		{
			if (Input.GetAxis("Jump") > 0 && IsGrounded)
			{
				playerbody.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
			}
		}
	}
}