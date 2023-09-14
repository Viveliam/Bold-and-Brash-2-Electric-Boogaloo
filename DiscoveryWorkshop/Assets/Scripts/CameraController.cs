using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Transform cameraTransform;
    private Vector3 offset;
    public float rotationSpeed = 5.0f; 
    
    void Start()
    {
        cameraTransform = transform.GetChild(0); 
        offset = cameraTransform.position - player.transform.position;
    }
    
    void LateUpdate()
    {
        cameraTransform.position = player.transform.position + offset;

        Vector3 movementDirection = player.GetComponent<Rigidbody>().velocity.normalized;
        
        if (movementDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movementDirection);
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
        
        transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
    }
}