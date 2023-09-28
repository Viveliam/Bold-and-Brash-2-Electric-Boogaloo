using UnityEngine;

namespace Player
{
    public class Die : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }
}
