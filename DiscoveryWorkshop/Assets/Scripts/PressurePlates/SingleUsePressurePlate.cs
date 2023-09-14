using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressureplate : MonoBehaviour
{
    [SerializeField]
    GameObject linkedObject;

    private void OnCollisionEnter(Collision other)
    {
        var script = linkedObject.GetComponent<Action>();
        script.DoAction();
    }
}
