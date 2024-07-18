using CinemachineSandbox.Tools;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CinemachineSandbox
{
    public abstract class Selector<T> : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private Variable<T> _selectionReference;
        
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
            CancelSelection();
        }
        
        public void OnClick(InputAction.CallbackContext context)
        {
            if (!context.control.IsPressed())
            {
                return;
            }
            
            var mousePos = Mouse.current.position.ReadValue();
            var origin = _mainCamera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(origin, out var hitInfo, 1000, _layerMask))
            {
                var selectable = hitInfo.collider.transform.parent;
                var result = selectable.GetComponent<T>();

                if (result != null)
                {
                    _selectionReference.SetValue(result);
                    OnSelect(result);
                }
                else
                {
                    CancelSelection();
                }
            }
            else
            {
                CancelSelection();
            }
        }
        
        private void CancelSelection()
        {
            if (_selectionReference.Value != null)
            {
                OnDeselect(_selectionReference.Value);
                _selectionReference.Clear();
            }
        }
        
        protected virtual void OnSelect(T selection) { }
        protected virtual void OnDeselect(T selection) { }
    }
}