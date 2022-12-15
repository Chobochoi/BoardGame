using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;


public class Movement : MonoBehaviourPunCallbacks
{
    private CharacterController controller;
    private new Transform transform;
    private Animator anim;
    private new Camera cam;
    
    // 가상의 Plane에 레이캐스팅하기 위한 변수
    private Plane plane;
    private Ray ray;
    private Vector3 hitPoint;

    private PhotonView PV;
    private CinemachineVirtualCamera virtualCamera;

    public float moveSpeed = 10.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        cam = Camera.main;

        PV = GetComponent<PhotonView>();
        virtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        if (PV.IsMine)
        {
            virtualCamera.Follow = transform;
            virtualCamera.LookAt = transform;
        }

        // 가상의 바닥을 주인공 위치를 기준으로 생성
        plane = new Plane(transform.up, transform.position);
    }

    void Update()
    {
        if (PV.IsMine)
        {
            Move();
            Turn();
        }
    }

    float h => Input.GetAxis("Horizontal");
    float v => Input.GetAxis("Vertical");

    void Move()
    {
        Vector3 cameraForward = cam.transform.forward;
        Vector3 cameraRight = cam.transform.right;
        cameraForward.y = 0.0f;
        cameraRight.y = 0.0f;

        // 이동할 벡터 계산
        Vector3 moveDir = (cameraForward * v) + (cameraRight * h);
        moveDir.Set(moveDir.x, 0.0f, moveDir.z);

        // 주인공 캐릭터 이동 처리
        controller.SimpleMove(moveDir * moveSpeed);
    }

    // 회전 처리
    void Turn()
    {
        // 나중에 수정필요 마우스포지션으로 함 (조이스틱으로 할 예정)
        ray = cam.ScreenPointToRay(Input.mousePosition);

        float enter = 0.0f;

        // 가상의 바닥에 레이를 발사해 충돌한 지점의 거리를 enter 변수로 변환
        plane.Raycast(ray, out enter);

        // 가상의 바닥에 레이가 충돌한 좌푯값 추출하기
        hitPoint = ray.GetPoint(enter);

        // 회전값
        Vector3 lookDir = hitPoint - transform.position;
        lookDir.y = 0.0f;

        // 회전값 지정
        transform.localRotation = Quaternion.LookRotation(lookDir);
    }
}
