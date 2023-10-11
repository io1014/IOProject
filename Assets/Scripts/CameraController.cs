using UnityEngine;
public class CameraController : MonoBehaviour
{
    Transform _target;
    void Start()
    {
        _target = FindObjectOfType<PlayerController>().transform; //타겟 정보   
    }
    void Update()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z); //타겟 쪽으로 이동
    }
}
