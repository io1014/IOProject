using UnityEngine;

public class DelegateExam : MonoBehaviour
{
    MyDelegate md;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            md += myFunc1;
        }
        if(Input.GetMouseButtonDown(1))
        {
            md -= myFunc1;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(md != null) md();
        }
    }

    void myFunc1()
    {
        Debug.Log("Input function 1");
    }
    void myFunc2()
    {
        Debug.Log("Input function 2");
    }
}
