using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float speed = 1.0f; 
    public float targetY = -2.0f; 
    public float movementDuration = 5.0f; 
    
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float elapsedTime = 0.0f;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = new Vector3(initialPosition.x, targetY, initialPosition.z);
    }

    private void Update()
    {
        if (elapsedTime < movementDuration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
    }
}