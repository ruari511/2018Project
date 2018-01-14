using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossState : MonoBehaviour {

    public enum Boss_CurrentState { Idle, Chase, Attack }
    public Boss_CurrentState curState = Boss_CurrentState.Idle;

    public bool isDead; // 보스는 죽지않아요!
    public float ViewFieldRange; // 추적범위 (대상을 추적 할 수있는 최대 거리)
    public float TrackingSpeed; // 추적속도 (추적 상태 시 몬스터의 이동 속도)
    public float TrackingTransform; // 추적전환 (공격 상태로 전환 하는 시간)
    // 추적 상태가 5초간 지속 될 경우, 다음 공격을 시도한다.
    public float AttackRange; // 공격범위 (임시)

    Transform m_transform; // 자신의 위치
    Transform p_transform; // 타겟 (플레이어) 위치

    NavMeshAgent nv; // 네비게이션인가 뭔가 그거 막 방해물 자동으로 피하고 그런거 있음

    void Start ()
    {
        isDead = false;
        m_transform = gameObject.GetComponent<Transform>();

        // 플레이어 태그를 가진 물체를 찾아서 위치를 가져옴
        p_transform = GameObject.FindWithTag("Player").GetComponent<Transform>();

        nv = gameObject.GetComponent<NavMeshAgent>();
        nv.speed = TrackingSpeed;
        nv.acceleration = nv.speed;

        StartCoroutine(CheckState());
        StartCoroutine(CheckState_Action());
    }

    IEnumerator CheckState()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(0.2f);

            float distance = Vector3.Distance(m_transform.position, p_transform.position);

            if(distance <= ViewFieldRange && distance > AttackRange) // 거리가 추적범위와 적거나 같다
            {
                curState = Boss_CurrentState.Chase;
            }
            else if (distance <= AttackRange) // 거리가 추적범위와 적거나 같다
            {
                curState = Boss_CurrentState.Attack;
            }
            else
            {
                curState = Boss_CurrentState.Idle;
            }
        }
    }

    IEnumerator CheckState_Action()
    {
        while (!isDead)
        {
            switch (curState)
            {
                case Boss_CurrentState.Idle:
                    nv.isStopped = true; // 정지상태다.
                    break;
                case Boss_CurrentState.Attack:
                    nv.isStopped = true; // 정지상태다.
                    break;
                case Boss_CurrentState.Chase:
                    nv.destination = p_transform.position;
                    nv.isStopped = false; // 정지상태가 아니다
                    break;
            }

            yield return null;
        }
    }
}
