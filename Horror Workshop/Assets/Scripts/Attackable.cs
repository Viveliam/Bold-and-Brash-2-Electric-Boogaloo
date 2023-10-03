using ScriptableObjects.Weapons;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class Attackable : MonoBehaviour
{
    private Entity _self;
    
    private void Start()
    {
        _self = GetComponent<Entity>();
    }

    //Take damage
    private void OnTriggerEnter(Collider other)
    {
        //Hit by weapon of player
        if (other.CompareTag("Weapon"))
        {
            var damage = other.GetComponent<PlayerAttackScript>().WeaponStats.damage;
            _self.Health -= damage;
        } 
        //Hit by enemy
        else if (other.CompareTag("Entity"))
        {
            //Need enemy attack script for this
            // var damage = other.GetComponent<Attackable>().Entity.damage;
            // _self.Health -= damage;
        }
    }
}
