using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CinemachineSandbox.Cameras
{
    [RequireComponent(typeof(PlayerInput))]
    public class BasicCycleCamera : MonoBehaviour
    {
        private PlayerInput _input;
        private List<CinemachineVirtualCamera> _virtualCameras;
        private int _currentCameraIndex = -1;
        
        private void Awake()
        {
            _virtualCameras = GetComponentsInChildren<CinemachineVirtualCamera>().ToList();
            _input = GetComponent<PlayerInput>();
            _input.actions["CycleCamera"].performed += _ => CycleCamera();
        }

        private void OnEnable()
        {
            _currentCameraIndex = -1;
            CycleCamera();
        }

        private void CycleCamera()
        {
            if (_currentCameraIndex >= 0)
            {
                _virtualCameras[_currentCameraIndex].Priority -= 100;
            }
        
            _currentCameraIndex = (_currentCameraIndex + 1) % _virtualCameras.Count;
            _virtualCameras[_currentCameraIndex].Priority += 100;
        }
    }
}