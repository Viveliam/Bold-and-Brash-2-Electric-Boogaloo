using System;
using UnityEngine;

namespace Player
{
    public class Pickup : MonoBehaviour
    {
        public int amountOfPictures = 0;
        public AudioSource audioSource;
        public AudioClip audioClip;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pickup"))
            {
                audioSource.PlayOneShot(audioClip);
                amountOfPictures++;
                Destroy(other.gameObject);
            }
        }
    }
}
