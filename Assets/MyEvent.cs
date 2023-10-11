using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyEvent : MonoBehaviour
{
    public event EventHandler loop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loop != null) loop(this, EventArgs.Empty);
    }
}
