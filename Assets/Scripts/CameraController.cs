using UnityEngine;
public class CameraController : MonoBehaviour
{
    Transform _target;
    void Start()
    {
        _target = FindObjectOfType<PlayerController>().transform; //Ÿ�� ����   
    }
    void Update()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z); //Ÿ�� ������ �̵�
    }
}
