using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public List<Weapon> unassignedWeapon, assignedWeapon;
    public int maxWeapon = 3; // 최대무기는 3개
    public Vector3 inputvec;
    public float speed;
    public float range;
    public Weapon weapon;
    public List<Weapon> MaxLevel = new List<Weapon>();
    SpriteRenderer sr;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        speed = PlayerStatController.instance.moveSpeed[0].value;
        range = PlayerStatController.instance.pickupRange[0].value;
        AddRandomWeapon();     
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        inputvec.x = x;
        inputvec.y = y;
        if(x>0)
        {
            sr.flipX = true;
        }
        else
        {
            sr .flipX = false;
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(inputvec.x, inputvec.y, 0).normalized * speed * Time.deltaTime);
    }
    public void AddRandomWeapon()
    {
        int x = Random.Range(0, unassignedWeapon.Count);
        {
            assignedWeapon.Add(unassignedWeapon[x]);
            unassignedWeapon[x].gameObject.SetActive(true);
            unassignedWeapon.RemoveAt(x); 
        }
    }
    public void AddWeapon(Weapon weapon)
    {
        weapon.gameObject.SetActive(true);
        assignedWeapon.Add(weapon);
        unassignedWeapon.Remove(weapon);
    }

  
    public float Setrange { get { return range; } }
    
    public float SetSpeed { get { return speed; } }

}
