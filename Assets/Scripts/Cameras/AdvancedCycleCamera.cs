using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CinemachineSandbox.Cameras
{
    [RequireComponent(typeof(PlayerInput))]
    public class AdvancedCycleCamera : MonoBehaviour
    {
        [SerializeField]
        private List<CinemachineVirtualCameraBase> _virtualCameras;
        
        private PlayerInput _input;
        
        private void Awake()
        {
            _input = GetComponent<PlayerInput>();
            _input.actions["CycleCamera"].performed += _ => CycleCamera();
        }

        private void OnEnable()
        {
            DisableAllCamera();
            _virtualCameras[0].enabled = true;
        }
        
        private void CycleCamera()
        {
            var currentCameraIndex = GetCurrentCameraIndex();

            if (currentCameraIndex == -1)
            {
                return;
            }
            
            _virtualCameras[currentCameraIndex].enabled = false;
            currentCameraIndex = (currentCameraIndex + 1) % _virtualCameras.Count;
            _virtualCameras[currentCameraIndex].enabled = true;
        }

        private int GetCurrentCameraIndex()
        {
            return _virtualCameras.FindIndex(x => x.enabled);
        }
        
        private void DisableAllCamera()
        {
            foreach (var vcam in _virtualCameras)
            {
                vcam.enabled = false;
            }
        }
    }
}