using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public GameObject enemy;
    public AudioSource source;
    public AudioClip clip;

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = enemy.GetComponent<Rigidbody>(); // Assuming the GameObject has a Rigidbody

        if (rb != null && rb.velocity.magnitude > 0)
        {
            if (!source.isPlaying)
            {
                source.loop = true; // Set the audio source to loop
                source.clip = clip;
                source.Play();
            }
        }
        else
        {
            source.loop = false; // Turn off looping if the GameObject is not moving
        }
    }
}