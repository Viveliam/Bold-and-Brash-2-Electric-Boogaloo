using System.Collections;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField] private EntityStats entityStats;
    private bool _canAttack;

    void Start()
    {
        //If weapon is in hands of player, can attack
        _canAttack = transform.parent != null;
    }

    void Update()
    {
        // if (_canAttack && click)
        // {
            //play animation/move weapon

            // StartCoroutine(Cooldown());
        // }
    }

    private IEnumerator Cooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(entityStats.attackCooldown);
        _canAttack = true;
    }

}
