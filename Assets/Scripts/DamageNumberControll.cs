using UnityEngine;
public class DamageNumberControll : MonoBehaviour
{
    public static DamageNumberControll _instance;
    private void Awake()
    {
        _instance = this;
    }
    [SerializeField] DamageNumber Spawn;
    [SerializeField] Transform Num; 
    public void SpawnDamage(float damage, Vector3 location)
    {
        DamageNumber Damage = Instantiate(Spawn,location,Quaternion.identity,Num);
        Damage.Setup(damage);
        Damage.gameObject.SetActive(true);
    }
}
