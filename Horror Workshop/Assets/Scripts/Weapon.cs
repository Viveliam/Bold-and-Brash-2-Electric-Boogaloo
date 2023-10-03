using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Weapons;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponStats weaponStats;

    public WeaponStats WeaponStats => weaponStats;
}
