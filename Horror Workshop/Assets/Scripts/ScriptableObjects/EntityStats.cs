using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "ScriptableObjects/Entity/EntityStats", order = 1)]
public class EntityStats : ScriptableObject
{
    public float health;
    //Attack animation speed
    [SerializeField] private float attackSpeed;
    public float attackCooldown;
    public float damage;
}
