using UnityEngine;

namespace Player
{
    public class DisableMouseInput : MonoBehaviour
    {
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    
    }
}
