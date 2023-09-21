using System;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    [SerializeField] private float lengthBetweenWalls = 6f;
    [SerializeField] private float speed;

    private bool _isTriggered = false;
    private float distanceMoved = 0f;

    private void Update()
    {
        if (_isTriggered)
        {
            Vector3 distToMove = Vector3.forward * speed * Time.deltaTime;
            leftWall.Translate(distToMove);
            rightWall.Translate(-distToMove);
            distanceMoved += distToMove.z;
            if (distanceMoved >= lengthBetweenWalls / 2)
            {
                _isTriggered = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trap");
        if (other.gameObject.CompareTag("Player"))
        {
            _isTriggered = true;
        }
    }
}
