using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNav : MonoBehaviour
{
    public float detectionRange;
    public float escapeRange;
    public Animator animator;

    private GameObject player;
    private NavMeshAgent enemy;
    private bool inChase;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionVector = player.transform.position - transform.position;
        float distance = directionVector.magnitude;
        if (!inChase)
        {
            if (distance < detectionRange)
            {
                inChase = true;
                animator.SetBool("isWalking", true);
            }
        } 
        else
        {
            enemy.SetDestination(player.transform.position);
            if (distance > escapeRange)
            {
                inChase = false;
                animator.SetBool("isWalking", false);
                enemy.SetDestination(transform.position);
            }
            
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Destroy(gameObject);
        }
    }
}
