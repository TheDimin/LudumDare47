using Cinemachine;
using LD47.GameStates;
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
            return GameManager.Instance.StateManager.GetState().GetType() == typeof(WalkingGameState);
        }

        public override bool CanExit()
        {
            return GameManager.Instance.StateManager.GetState().GetType() == typeof(PreGameState) ||
                   GameManager.Instance.StateManager.GetState().GetType() == typeof(MiniGameState);
        }

        public override void OnEnterState()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.CrosshairCanvas.SetActive(true);
            player.PlayerPointer.CanDetect = true;
        }

        public override void OnExitState()
        {

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
                player.Playerbody.velocity += Vector3.up * player.JumpForce ;
            }


            player.Playerbody.velocity = (movement * player.MovementSpeed * 100 * Time.fixedDeltaTime + ((Vector3.up * player.Playerbody.velocity.y) + Physics.gravity * Time.deltaTime));
        }

        private void Rotate()
        {
            player.transform.Rotate(Vector3.up * (player.LookSpeed * Input.GetAxis("Mouse X") * Time.deltaTime));

            xRotation -= Input.GetAxis("Mouse Y") * player.LookSpeed * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        }

        private Vector3 movement;
        private void Walk()
        {
            movement = player.transform.right * Input.GetAxis("Horizontal") + player.transform.forward * Input.GetAxis("Vertical");
        }
    }
}