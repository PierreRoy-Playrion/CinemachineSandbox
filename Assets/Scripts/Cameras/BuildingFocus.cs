using UniRx;
using UnityEngine;

namespace CinemachineSandbox.Cameras
{
    [RequireComponent(typeof(AdvancedCameraRig))]
    public class BuildingFocus : MonoBehaviour
    {
        [SerializeField]
        private BuildingVariable _selectedBuilding;

        private AdvancedCameraRig _cameraRig;
        
        private void Start()
        {
            _cameraRig = GetComponent<AdvancedCameraRig>();
            
            _selectedBuilding.Property
                .Subscribe(OnSelectedBuildingValueChanged)
                .AddTo(gameObject);
        }
        
        private void OnSelectedBuildingValueChanged(Building building)
        {
            if (building == null)
            {
                _cameraRig.FreeLookCamera.enabled = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                FocusBuilding(building);
            }
        }

        private void FocusBuilding(Building building)
        {
            Cursor.lockState = CursorLockMode.Locked;
            building.Camera.enabled = true;
            _cameraRig.FreeLookCamera.enabled = false;
        }
    }
}