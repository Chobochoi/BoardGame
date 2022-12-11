using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;

    // 따라갈 대상으로부터 떨어질 거리
    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;

    // Y축
    [Range(0.0f, 10.0f)]
    public float height = 2.0f;

    // 반응속도
    public float damping = 10.0f;

    // 카메라 LookAt의 Offset 값
    public float targetOffset = 2.0f;

    private Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        camTr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Vector3 pos = targetTr.position
            + (-targetTr.forward * distance)
            + (Vector3.up * height);

        camTr.position = Vector3.SmoothDamp(camTr.position, pos, ref velocity, damping);
        camTr.LookAt(targetTr.position + (targetTr.up * targetOffset));
    }

    void Update()
    {
        
    }
}
