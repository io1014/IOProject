using UnityEngine;
public class CoinRotation : MonoBehaviour
{
    float rotateSpeed = 180;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + (rotateSpeed * Time.deltaTime * 4), 0f);
    }
}
