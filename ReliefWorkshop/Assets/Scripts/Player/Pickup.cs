using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] int amountToWin = 3;
        public int amountOfPictures = 0;
        public AudioSource audioSource;
        public AudioClip audioClip;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pickup"))
            {
                audioSource.PlayOneShot(audioClip);
                amountOfPictures++;
                print(amountOfPictures.ToString());
                Destroy(other.gameObject);
            }

            if (amountOfPictures >= amountToWin)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
