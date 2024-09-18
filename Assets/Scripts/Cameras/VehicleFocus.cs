using UniRx;
using UnityEngine;

namespace CinemachineSandbox.Cameras
{
    [RequireComponent(typeof(AdvancedCameraRig))]
    public class VehicleFocus : MonoBehaviour
    {
        [SerializeField]
        private VehicleVariable _selectedVehicle;

        private AdvancedCameraRig _cameraRig;
        
        private void Start()
        {
            _cameraRig = GetComponent<AdvancedCameraRig>();
            
            _selectedVehicle.Property
                .Subscribe(OnSelectedVehicleValueChanged)
                .AddTo(gameObject);
        }
        
        private void OnSelectedVehicleValueChanged(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                _cameraRig.FreeLookCamera.enabled = true;
                _cameraRig.VehiclePovCamera.enabled = false;
                _cameraRig.VehicleGroundCamera.enabled = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                FocusVehicle(vehicle);
            }
        }

        private void FocusVehicle(Vehicle vehicle)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _cameraRig.VehiclePovCamera.Follow = vehicle.transform;
            _cameraRig.VehiclePovCamera.LookAt = vehicle.transform;
            _cameraRig.VehicleGroundCamera.Follow = vehicle.transform;
            _cameraRig.VehicleGroundCamera.LookAt = vehicle.transform;
            _cameraRig.VehiclePovCamera.enabled = true;
            _cameraRig.VehicleGroundCamera.enabled = false;
            _cameraRig.FreeLookCamera.enabled = false;
        }
    }
}