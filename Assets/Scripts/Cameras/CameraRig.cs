using Cinemachine;
using UnityEngine;

namespace CinemachineSandbox.Cameras
{
    public class CameraRig : MonoBehaviour
    {
        [SerializeField]
        private Camera _mainCamera;
        
        [SerializeField]
        private CinemachineFreeLook _freeLookCamera;

        public Camera MainCamera => _mainCamera;
        public CinemachineFreeLook FreeLookCamera => _freeLookCamera;
    }
}