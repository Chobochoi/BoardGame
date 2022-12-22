using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Transform tr;
    // 애니메이션 나중에 넣기
    public float moveSpeed = 10.0f;
    public float turnSpeed = 10.0f;

    // 시작할때 체력입니다.
    private readonly float startHP = 100.0f;
    // 현재 체력입니다.
    public float currHP;

    // PlayerDie에 대한 델리게이트 함수입니다.
    public delegate void PlayerDieHandler();
    // PlayerDie에 대한 이벤트 선언입니다.
    public static event PlayerDieHandler OnPlayerDie;
        
    void Start()
    {
        tr = GetComponent<Transform>();
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);
    }

    // 나중에 애니메이션 넣기

    void PlayerDie()
    {
        Debug.Log("Player Die");

        //// Monster 태그를 가진 모든 게임오브젝트를 찾아옵니다.
        //GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

        //// 모든 몬스터의 OnplayerDie 함수를 순차적으로 호출합니다.
        //foreach (GameObject monster in monsters)
        //{
        //    monster.SendMessage("Player Die Now", SendMessageOptions.DontRequireReceiver);
        //}
        OnPlayerDie();
    }    
}
