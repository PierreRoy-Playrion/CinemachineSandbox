using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CinemachineSandbox.Cameras
{
    [RequireComponent(typeof(CinemachineImpulseSource))]
    public class CameraImpulseTrigger : MonoBehaviour
    {
        [SerializeField]
        private float _force = 1;
        
        private PlayerInput _input;
        private CinemachineImpulseSource _impulseSource;
        
        private void Awake()
        {
            _impulseSource = GetComponent<CinemachineImpulseSource>();
            _input = GetComponentInParent<PlayerInput>();
            _input.actions["Brrrr"].performed += Brrrr;
        }

        private void Brrrr(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _impulseSource.GenerateImpulseWithForce(_force);
            }
        }
    }
}