using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    Transform _target;
    void Start()
    {
        _target = FindObjectOfType<PlayerController>().transform; //Ÿ�� ����
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_target.position.x,_target.position.y,transform.position.z); //Ÿ�� ������ �̵�
        
        
    }
}
