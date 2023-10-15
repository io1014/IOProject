using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public List<Weapon> unassignedWeapon, assignedWeapon;
    public int maxWeapon = 3; // �ִ빫��� 3��
    public Vector3 inputvec;
    public float speed;
    public float range;
    public Weapon weapon;
    public List<Weapon> MaxLevel = new List<Weapon>();
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
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
