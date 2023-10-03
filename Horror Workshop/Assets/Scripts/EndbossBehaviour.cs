using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndbossBehaviour : MonoBehaviour
{
    public float detectionRange;
    public float escapeRange;
    public Animator animator;
    public GameObject prefab;

    private GameObject player;
    private bool isFighting;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionVector = player.transform.position - transform.position;
        float distance = directionVector.magnitude;
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
            throwItem();
            if (distance > escapeRange)
            {
                isFighting = false;
                animator.SetBool("isFighting", false);
            }
            
        }
    }

    void throwItem()
    {

    }
}
