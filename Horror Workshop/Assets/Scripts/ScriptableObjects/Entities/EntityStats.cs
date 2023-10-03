using UnityEngine;

namespace ScriptableObjects.Entities
{
    [CreateAssetMenu(fileName = "EntityStats", menuName = "ScriptableObjects/Entity/EntityStats", order = 1)]
    public class EntityStats : ScriptableObject
    {
        public float maxHealth;
    }
}
