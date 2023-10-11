using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTextAnim : MonoBehaviour
{
    [SerializeField] string[] _texts;
    Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text= GetComponent<Text>();
        StartCoroutine(CoTextAni());
        
    }

    IEnumerator CoTextAni()
    {
        int i = 0;
        while(true)
        {
            _text.text = _texts[i];
            i++;
            if (i >= _texts.Length) i = 0;
            yield return new WaitForSeconds(0.2f);
        }
    }
    
}
