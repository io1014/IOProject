using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;
    public float maxhealth , currenthealth;
    [SerializeField]
    Slider healthSlider;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        maxhealth = PlayerStatController.instance.health[0].value;
        currenthealth = maxhealth;
        healthSlider.maxValue = maxhealth;
        healthSlider.value= currenthealth;

    }
    void Update()
    {
        healthSlider.maxValue = maxhealth;
        healthSlider.value = currenthealth;
    }
    public void UpdateBtn()
    {
        if (UIController.Instance.LevelUpPanel.activeSelf == true)
        {
        }
    }
    public void TakeDamage(float damage)
    {
        currenthealth -= damage;

        if(currenthealth <= 0)
        {
            gameObject.SetActive(false);
        }
        healthSlider.value = currenthealth;
    }

  

}
