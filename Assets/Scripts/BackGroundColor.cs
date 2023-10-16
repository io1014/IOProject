using UnityEngine;
using UnityEngine.UI;

public class BackGroundColor : MonoBehaviour
{
    [SerializeField]public Slider slider;
    public Gradient gradient;
    public GameObject LevelupPanel;
    float t =1; 
    Image image;
    private void Start()
    {
        slider = GetComponent<Slider>();
        image = transform.GetComponent<Image>();
    }
    void Update()
    {
        t -= Time.unscaledDeltaTime;
        if (t <= 0) t = 1;

        if (Time.timeScale == 0)
        {
            if (LevelupPanel.activeSelf == true)
            {
                image.color = gradient.Evaluate(t);
            }
        }
        if (Time.timeScale ==1)
        {
            image.color = Color.black;
        }
    }
}
