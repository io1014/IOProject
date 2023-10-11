using UnityEngine;
using TMPro;
public class DamageNumber : MonoBehaviour
{
    [SerializeField] TMP_Text damageText;
    float lifeTime = 1;
    float lifeCounter;
    void Start()
    {
        lifeCounter = lifeTime;
    }
    void Update()
    {
        if (lifeCounter > 0)
        {
            lifeCounter -= Time.deltaTime;
            if (lifeCounter <= 0)
            {
                Destroy(gameObject);
            }
        }
        transform.position += Vector3.up * 1 * Time.deltaTime;
    }
    public void Setup(float damageDisplay)
    {
        lifeCounter = lifeTime;
        damageText.text = damageDisplay.ToString();
    }
}

