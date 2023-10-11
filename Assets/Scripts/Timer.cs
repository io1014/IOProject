using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]Text TimeTimer;
    DateTime starttime;
    
    private void Awake()
    {
        starttime  = DateTime.Now;
        InvokeRepeating("UpdateClockTIme", 0f, 0.01f);
        
    }
    void UpdateClockTIme()
    {
        TimeTimer.text = string.Format("{0:mm\\:ss\\:ff}", Playtime());
    }
    TimeSpan Playtime()
    {
        return DateTime.Now - starttime;
    }
}
