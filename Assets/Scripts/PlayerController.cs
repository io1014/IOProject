using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField]public List<Weapon> unassignedWeapon, assignedWeapon;
    int maxWeapon = 3;
    public Vector3 inputvec;

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
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        inputvec.x = x;
        inputvec.y = y;
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(inputvec.x, inputvec.y, 0).normalized * speed * Time.deltaTime);
    }

    public float Setrange { get { return range; } }
    
    public float SetSpeed { get { return speed; } }

}
