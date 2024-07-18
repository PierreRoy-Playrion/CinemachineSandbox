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

        [SerializeField]
        private CinemachineVirtualCamera _vehiclePovCamera;

        [SerializeField]
        private CinemachineVirtualCamera _vehicleGroundCamera;

        public Camera MainCamera => _mainCamera;
        public CinemachineFreeLook FreeLookCamera => _freeLookCamera;
        public CinemachineVirtualCamera VehiclePovCamera => _vehiclePovCamera;
        public CinemachineVirtualCamera VehicleGroundCamera => _vehicleGroundCamera;
    }
}