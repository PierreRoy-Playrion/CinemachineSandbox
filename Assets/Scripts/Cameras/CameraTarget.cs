using UnityEngine;

namespace CinemachineSandbox.Cameras
{
    public class CameraTarget : MonoBehaviour
    {
        [SerializeField]
        private bool _showGizmos;
        
        private void OnDrawGizmos()
        {
            if (_showGizmos)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(transform.position, Vector3.one * 0.3f);
            }
        }
    }
}