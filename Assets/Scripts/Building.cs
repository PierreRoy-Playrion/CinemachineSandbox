using Cinemachine;
using UnityEngine;

namespace CinemachineSandbox
{
    public class Building : MonoBehaviour
    {
        public CinemachineVirtualCamera Camera { get; private set; }

        private void Awake()
        {
            Camera = GetComponentInChildren<CinemachineVirtualCamera>();
        }
    }
}