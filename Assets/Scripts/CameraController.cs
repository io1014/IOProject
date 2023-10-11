using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    Transform _target;
    void Start()
    {
        _target = FindObjectOfType<PlayerController>().transform; //타겟 정보
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_target.position.x,_target.position.y,transform.position.z); //타겟 쪽으로 이동
        
        
    }
}
