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
    private Animator _animator;
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

    void Start()
    {
        _animator = GetComponent<Animator>();
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
        
        _animator.SetBool(IsAttacking, true);
            
    
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        
        _collider.enabled = false;
        _shootPress = false;
        _animator.SetBool(IsAttacking, false);
        _canAttack = true;
    }

    public WeaponStats WeaponStats => _weaponStats;

    private void OnFire(InputValue inputValue)
    {
        _shootPress = true;
    }
}
