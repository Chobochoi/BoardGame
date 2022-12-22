using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 내비게이션 기능을 사용하기 위해 꼭 추가해주세요.
using UnityEngine.AI;

public class MonsterControl : MonoBehaviour
{
    // 몬스터들의 다양한 상태들을 Enum으로 만들어 놓습니다.
    public enum MonsterState
    {
        IDLE, TRACE, ATTACK, DIE
    }

    // 몬스터의 현재상태입니다. (가만히 있기)
    public MonsterState state = MonsterState.IDLE;
    // 쫓는 사정거리를 지정합니다.
    public float traceDis = 8.0f;
    // 공격 사정거리를 지정합니다.
    public float attackDis = 2.0f;
    // 몬스터의 생존여부입니다.
    public bool isDie = false;

    private Transform monsterTrans;
    private Transform playerTrans;
    private NavMeshAgent agent;

    // 몬스터의 체력입니다.
    private int HP = 100;

    void Start()
    {
        // 몬스터의 Transform 입니다.
        monsterTrans = GetComponent<Transform>();
        // 몬스터가 쫓아야 하는 플레이어의 Transform 입니다.
        // FindWithTag와 같은 Find 함수는 처리속도가 느리기 때문에 절대 Update문에서는 지양해야합니다. Awake나 Start 함수에서 할당한 후 사용해주세요.
        playerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
        // NavMeshAgent 입니다.
        agent = GetComponent<NavMeshAgent>();
        // 몬스터의 상태를 체크하는 코루틴 함수 입니다.
        StartCoroutine(CheckMonsterState());
        // 몬스터의 상태에 따라 몬스터의 동작을 제어하는 함수입니다.
        StartCoroutine(MonsterAct());
    }

    // 일정 시간마다 몬스터의 행동을 체크합니다.
    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            // 몬스터와 플레이어의 사이의 거리를 측정합니다.
            float distance = Vector3.Distance(playerTrans.position, monsterTrans.position);

            // 공격 사정거리 범위로 들어왔는지 확인합니다.
            if (distance <= attackDis)
            {
                state = MonsterState.ATTACK;
            }

            // 쫓는 사정거리 범위로 들어왔는지 확인합니다.
            else if (distance <= traceDis)
            {
                state = MonsterState.TRACE;
            }

            // 둘 다가 아니면 IDLE 상태로 대기합니다.
            else
            {
                state = MonsterState.IDLE;
            }
        }
    }

    IEnumerator MonsterAct()
    {
        while (!isDie)
        {
            switch (state)
            {
                // IDLE 상태입니다.
                case MonsterState.IDLE:
                    // 쫓기를 멈춥니다.
                    agent.isStopped = true;
                    break;

                // TRACE 상태입니다.
                case MonsterState.TRACE:
                    // 쫓는 대상의 좌표로 이동합니다.
                    agent.SetDestination(playerTrans.position);
                    agent.isStopped = false;
                    break;

                // ATTACk 상태입니다.
                case MonsterState.ATTACK:
                    break;

                // DIE 상태입니다.
                case MonsterState.DIE:
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnPlayerDie()
    {
        // 몬스터의 상태를 체크하는 모든 코루틴 함수를 정지시킵니다.
        StopAllCoroutines();

        // 쫓기를 중지하고 애니메이션을 주생합니다.
        agent.isStopped = true;
        //anim.SetTrigger(hasPlayerDie);
    }

    private void OnEnable()
    {
        PlayerControl.OnPlayerDie += this.OnPlayerDie;
    }

    private void OnDisable()
    {
        PlayerControl.OnPlayerDie -= this.OnPlayerDie;
    }
}
