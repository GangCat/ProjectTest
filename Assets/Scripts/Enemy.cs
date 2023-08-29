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
            // �÷��̾ ������ Ÿ������������ ������ �÷��̾� ���������� Ÿ�� ����
            float curTime = Time.time;
            targetPos = towerPos;
            moveDir = (targetPos - transform.position);
            transform.rotation = Quaternion.LookRotation(moveDir);
            while (Time.time - curTime < 0.5f)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                yield return null;
            }

            // 1. 0.5�ʿ� �ѹ��� ���� �˻�
            // 2. ������ �÷��̾�� Ÿ�� ����
            // 3. ������ 1�ʰ� ��� �� Ÿ���� Ÿ�� ����
        }
    }

    [SerializeField]
    private float moveSpeed = 2f;

    private Transform playerTr = null;

    private Vector3 moveDir = Vector3.zero;
    private Vector3 towerPos = Vector3.zero;
    private Vector3 targetPos = Vector3.zero;
}
