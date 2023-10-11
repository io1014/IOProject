using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    Rigidbody2D AXERig;
    float power = 4;
    float rotateSpeed = 2;

    void Start()
    {
        AXERig = GetComponent<Rigidbody2D>();
        AXERig.velocity = new Vector2(Random.Range(-power, power), power);


    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotateSpeed * 360 * Time.deltaTime * Mathf.Sign(AXERig.velocity.x)));
    }
}




