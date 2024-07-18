using UnityEngine;
using UnityEngine.InputSystem;

namespace CinemachineSandbox
{
    public class BuildingSelector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _selectableMask;

        [SerializeField]
        private BuildingVariable _selectedBuilding;
        
        private Camera _mainCamera;
        private PlayerControls _playerControls;

        private void Start()
        {
            _mainCamera = Camera.main;

            _playerControls = new PlayerControls();
            _playerControls.Player.Select.performed += OnClick;
            _playerControls.Player.Back.performed += OnBack;
            _playerControls.Enable();
        }

        private void OnDestroy()
        {
            _playerControls.Player.Select.performed -= OnClick;
        }

        private void OnBack(InputAction.CallbackContext contract)
        {
            _selectedBuilding.Clear();
        }
        
        public void OnClick(InputAction.CallbackContext context)
        {
            if (!context.control.IsPressed())
            {
                return;
            }
            
            var mousePos = Mouse.current.position.ReadValue();
            var origin = _mainCamera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(origin, out var hitInfo, 1000, _selectableMask))
            {
                var selectable = hitInfo.collider.transform.parent;
                var building = selectable.GetComponent<Building>();
                _selectedBuilding.SetValue(building);
            }
            else
            {
                _selectedBuilding.Clear();
            }
        }
    }
}
