using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] MyEvent _event;
    // Start is called before the first frame update
    void Start()
    {
        _event.loop += new System.EventHandler(loopEvent);
    }

    void loopEvent(object sender, EventArgs s)
    {
        Debug.Log("Call here");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
