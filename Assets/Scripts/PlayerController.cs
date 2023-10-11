using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] List<Weapon> unassignedWeapon, assignedWeapon;
    int maxWeapon = 3;

    private void Awake()
    {
        instance = this;
    }
    public float speed;
    public float range;

    public Weapon weapon;
    void Start()
    {
        speed = PlayerStatController.instance.moveSpeed[0].value;
        range = PlayerStatController.instance.pickupRange[0].value;

        
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
