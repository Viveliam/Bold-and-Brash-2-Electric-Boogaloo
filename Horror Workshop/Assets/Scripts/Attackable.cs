using UnityEngine;

public class Attackable : MonoBehaviour
{
    [SerializeField] private EntityStats stats;

    //Take damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") || other.CompareTag("Entity"))
        {
            var damage = other.GetComponent<Attackable>().Stats.damage;
            stats.damage -= damage;
        }
    }

    public EntityStats Stats => stats;
}
