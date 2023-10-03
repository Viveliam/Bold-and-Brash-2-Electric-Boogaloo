using System.Collections;
using ScriptableObjects.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackScript : MonoBehaviour
{
    private WeaponStats _weaponStats;
    private bool _canAttack;
    private bool _shootPress;
    private BoxCollider _collider;

    void Start()
    {
        //If weapon is in hands of player, can attack
        _canAttack = transform.childCount != 0;

        if (_canAttack)
        {
            var weapon = transform.GetChild(0);
            _collider = weapon.GetComponent<BoxCollider>();
            _collider.enabled = false;
            _weaponStats = weapon.GetComponent<Weapon>().WeaponStats;
        }
        
        _shootPress = false;
    }

    void Update()
    {
         if (_canAttack && _shootPress)
         {
             StartCoroutine(Attack());
         }
    }
    
    private IEnumerator Attack()
    {
        _canAttack = false;
        _collider.enabled = true;
        print(_collider.enabled.ToString());
        //Animatiesnelheid uit controller halen
        var animationSpeed = 1f;
        // play animation/move of child weapon with speed attackSpeed
            
    
        yield return new WaitForSeconds(animationSpeed);

        _collider.enabled = false;
        _shootPress = false;
        
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_weaponStats.attackCooldown);
        _canAttack = true;
    }

    public WeaponStats WeaponStats => _weaponStats;

    private void OnFire(InputValue inputValue)
    {
        _shootPress = true;
    }
}
