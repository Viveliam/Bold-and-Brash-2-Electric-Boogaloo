using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource source; // This should be assigned in the Inspector
    public AudioClip clip;
    public Transform target; // The target (camera) to measure the distance to

    public float maxVolumeDistance = 10.0f; // Adjust this distance for your needs
    private EnemyBehaviour _enemyBehaviour;

    private void Start()
    {
        if (target == null)
        {
            // If the target (camera) is not assigned, use the main camera as the default target.
            target = Camera.main.transform;
        }

        _enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyBehaviour.GetEnemyState == EnemyBehaviour.EnemyState.Hunt)
        {
            if (!source.isPlaying)
            {
                source.loop = true;
                source.clip = clip;
                source.Play();
            }

            // Calculate the distance between the GameObject and the target (camera).
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // Calculate the volume based on distance.
            float volume = Mathf.Clamp01(1 - (distanceToTarget / maxVolumeDistance));
            source.volume = volume;
        }
        else
        {
            source.loop = false;
        }
    }
}