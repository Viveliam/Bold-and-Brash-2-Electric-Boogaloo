using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Die : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag("Enemy"))
            {
                SceneManager.LoadScene("DeathScene");
            }
        }
    }
}
