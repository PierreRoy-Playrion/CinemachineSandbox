using UnityEngine;
using UnityEngine.InputSystem;

namespace CinemachineSandbox.Cameras
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(AdvancedCameraRig))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private float _moveSensitivity = 2f;

        [SerializeField]
        private float _moveDampening = 8f;
        
        [SerializeField]
        private float _zoomSensitivity = 0.5f;

        [SerializeField]
        private float _zoomMin = 3;

        [SerializeField]
        private float _zoomMax = 15;
        
        private PlayerInput _input;
        private AdvancedCameraRig _cameraRig;

        private Vector3 _targetPosition;
        
        private void Awake()
        {
            _input = GetComponent<PlayerInput>();
            _cameraRig = GetComponent<AdvancedCameraRig>();
        }

        private void Update()
        {
            Move();
            
            var targetTransform = _cameraRig.FreeLookCamera.Follow.transform;
            targetTransform.position = Vector3.Lerp(
                targetTransform.position,
                _targetPosition,
                Time.deltaTime * 4);
        }

        private void Move()
        {
            var input = _input.actions["Move"].ReadValue<Vector2>();
            if (input == Vector2.zero)
            {
                return;
            }

            var translation = _cameraRig.MainCamera.transform.TransformDirection(input);
            translation = new Vector3(translation.x, 0, translation.z) * _moveSensitivity;
            _targetPosition += translation * Time.deltaTime;
        }
    }
}