using UnityEngine;

namespace ScriptableObjects.Weapons
{
    [CreateAssetMenu(fileName = "EntityStats", menuName = "ScriptableObjects/Weapon/WeaponStats", order = 1)]
    public class WeaponStats : ScriptableObject
    {
        //Attack animation speed
        [SerializeField] private float attackSpeed;
        public float attackCooldown;
        public float damage;
    }
}