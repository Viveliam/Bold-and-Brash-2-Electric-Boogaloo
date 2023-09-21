using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Image iconImage;  // Reference to the Image component for the item icon

    // Method to update the item display with a specific icon
    public void UpdateItemDisplay(Sprite itemIcon, int index)
    {
        // Set the icon image to the provided item icon
        if (iconImage != null)
        {
            iconImage.sprite = itemIcon;
        }
        else
        {
            Debug.LogError("IconImage reference not set for ItemDisplay at index " + index);
        }
    }
}
