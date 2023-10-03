using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private Entity _entity;
    
    // Start is called before the first frame update
    void Start()
    {
        _entity = GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = _entity.Health / _entity.EntityStats.maxHealth;
    }
}
