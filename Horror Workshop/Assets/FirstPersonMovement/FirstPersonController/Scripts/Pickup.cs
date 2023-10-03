using TMPro;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int KeyCounter = 0;
    public TMP_Text Text;

    private void Start()
    {
        Text.text = "x " + KeyCounter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            KeyCounter++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("UnlockableDoor") && KeyCounter > 0)
        {
            KeyCounter--;
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        Text.text = "x " + KeyCounter;
    }
}
