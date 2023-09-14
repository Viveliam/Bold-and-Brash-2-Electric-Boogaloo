using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressureplate : MonoBehaviour
{
    [SerializeField]
    GameObject actionTarget;

    private void OnCollisionEnter(Collision other)
    {
        var script = actionTarget.GetComponent<Action>();
        script.DoAction();
    }
}
