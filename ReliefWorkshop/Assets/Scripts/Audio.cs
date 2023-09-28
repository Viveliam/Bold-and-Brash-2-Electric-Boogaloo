using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource source; // This should be assigned in the Inspector
    public AudioClip clip;
    public Transform player; // The player GameObject
    public float maxVolumeDistance = 10.0f; // Adjust this distance for your needs
    private EnemyBehaviour _enemyBehaviour;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            // If the player is not assigned, find it by its tag (you can change the tag or use a different method to find it).
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (player != null)
        {
            // Calculate the distance between the enemy (this GameObject) and the player.
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Calculate the volume based on distance.
            float volume = Mathf.Clamp01(1 - (distanceToPlayer / maxVolumeDistance));

            if (volume > 0)
            {
                if (!source.isPlaying)
                {
                    source.loop = true;
                    source.clip = clip;
                    source.Play();
                }
            }
            else
            {
                source.loop = false;
            }

            // Set the audio source's volume based on the calculated volume.
            source.volume = volume;
        }
    }
}