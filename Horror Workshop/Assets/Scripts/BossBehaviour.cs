using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float detectionRange;
    public float escapeRange;
    public Animator animator;
    public GameObject prefab;
    public float throwingSpeed;
    public float objectDisappearTime;

    private GameObject player;
    private Rigidbody rb;
    private bool isFighting;
    private float waitTime;
    private int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        waitTime = 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionVector = player.transform.position - transform.position;
        float distance = directionVector.magnitude;
        Vector3 newVec = new Vector3(directionVector.x, 0, directionVector.z);
        Quaternion angle = Quaternion.LookRotation(newVec * Time.deltaTime);
        rb.MoveRotation(angle);
        if (!isFighting)
        {
            if (distance < detectionRange)
            {
                isFighting = true;
                animator.SetBool("isFighting", true);
            }
        }
        else
        {
            if (waitTime > 1.2)
            {
                throwItem(directionVector.normalized);
                waitTime = 0;
            } else
            {
                waitTime += Time.deltaTime;
            }
            
            if (distance > escapeRange)
            {
                isFighting = false;
                animator.SetBool("isFighting", false);
            }

        }
    }

   

    void throwItem(Vector3 direction)
    {
        GameObject temp = Instantiate(prefab, transform.position + Vector3.up * 2 + transform.forward, transform.rotation);
        Rigidbody tempRB = temp.GetComponent<Rigidbody>();
        Vector3 throwingAngle = new Vector3(direction.x, direction.y - 0.1f, direction.z);
        tempRB.velocity = throwingAngle * throwingSpeed;
        StartCoroutine(destroyGameobject(temp));
    }
    
    IEnumerator destroyGameobject(GameObject obj)
    {
        Debug.Log("Destroy");
        
        yield return new WaitForSeconds(objectDisappearTime);
        Destroy(obj);

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            } else
            {
                health--;
            }
            
        }
    }
}
