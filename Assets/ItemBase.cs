using UnityEngine;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour
{
    [SerializeField] Text _Scale;
    [SerializeField] Text _Count;
    [SerializeField] Text _Type;

    public void Init(ItemData data)
    {
        _Scale.text = data.Scale.ToString();
        _Count.text = data.Count.ToString();
        _Type.text = data.Type.ToString();
        gameObject.SetActive(true);
    }
}
