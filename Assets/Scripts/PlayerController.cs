using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }


    public float speed = 3;
    public float range = 2f;

    public Weapon weapon;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x, y, 0).normalized * speed * Time.deltaTime);
    }

    public float Setrange { get { return range; } }
    
    public float SetSpeed { get { return speed; } }

}
