using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Init(Vector3 _SpawnPos, Transform _playerTr, Vector3 _towerPos)
    {
        transform.position = _SpawnPos;
        playerTr = _playerTr;
        towerPos = _towerPos;
        StartCoroutine("MoveToTarget");
    }

    private IEnumerator MoveToTarget()
    {
        while (true)
        {
            // 플레이어가 없으면 타워포지션으로 있으면 플레이어 포지션으로 타겟 설정
            float curTime = Time.time;
            targetPos = towerPos;
            moveDir = (targetPos - transform.position);
            transform.rotation = Quaternion.LookRotation(moveDir);
            while (Time.time - curTime < 0.5f)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                yield return null;
            }

            // 1. 0.5초에 한번씩 주위 검사
            // 2. 있으면 플레이어로 타겟 변경
            // 3. 없으면 1초간 대기 후 타워로 타겟 변경
        }
    }

    [SerializeField]
    private float moveSpeed = 2f;

    private Transform playerTr = null;

    private Vector3 moveDir = Vector3.zero;
    private Vector3 towerPos = Vector3.zero;
    private Vector3 targetPos = Vector3.zero;
}
