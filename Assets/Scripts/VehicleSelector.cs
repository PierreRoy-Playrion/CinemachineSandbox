using CinemachineSandbox.Cameras;
using UnityEngine;

namespace CinemachineSandbox
{
    public class VehicleSelector : Selector<Vehicle>
    {
        [SerializeField]
        private CameraRig _cameraRig;
        
        protected override void OnDeselect(Vehicle selection)
        {
            _cameraRig.VehiclePovCamera.enabled = false;
        }
    }
}