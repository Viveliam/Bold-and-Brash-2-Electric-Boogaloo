using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryInstance : ScriptableObject
{
    public List<ItemData> items = new();
}
