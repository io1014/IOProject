using UnityEngine;

public class FSMPractice : MonoBehaviour // zombieController
{
    [SerializeField] Transform[] _patrollPoint;
    [SerializeField] Transform _target;
    [SerializeField] float _speed;
    [SerializeField] float _attackMoveSpeed;

    int _patIndex = 0;

    private void Start()
    {
        GetComponent<ZombieFSM>().ChangeStateByEnum(ZombieState.Idle);
    }

    
    public void StartAnim(string AniName)
    {
        GetComponent<Animator>().Play("Idle");
        if (AniName.Equals("Die"))
        {
            GetComponent<Animator>().SetTrigger("ZombieDie");
        }
        else if (AniName.Equals("Attack"))
        {
            GetComponent<Animator>().SetTrigger("Attack");
        }
       
        else
        {
            Debug.Log($"State에서 {AniName} 애니메이션을 실행했습니다.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<ZombieFSM>().ChangeStateByEnum(ZombieState.Die);
        }
    }

    public Transform GetNowPatPoint() => _patrollPoint[_patIndex];
    public Transform GetTargetTrans() => _target;
    public float GetMoveSpeed() => _speed;
    public float GetAttackMoveSpeed() => _attackMoveSpeed;
    public void AddPatIndex()
    {
        _patIndex++;
        if (_patIndex >= _patrollPoint.Length) _patIndex = 0;
    }

}
