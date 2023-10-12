using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundColor : MonoBehaviour
{
    public Gradient gradient;
    float t =1; 
    Image image;
    private void Start()
    {
        image = transform.GetComponent<Image>();
    }
    void Update()
    {
        t -= Time.unscaledDeltaTime;
        if (t <= 0) t = 1;
        Debug.Log(t);

        if (Time.timeScale == 0)
        { 
            image.color = gradient.Evaluate(t); 
        }
    }
}
