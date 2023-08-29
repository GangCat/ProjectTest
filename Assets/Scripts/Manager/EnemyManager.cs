using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public void Init(Transform _playerTr, Vector3 _targetPos)
    {
        gm = GameManager.Instance;
        //enemyPrefab = Resources.Load<GameObject>("Prefabs\\P_Enemy");
        playerTr = _playerTr;
        targetPos = _targetPos;
    }

    public void SpawnEnemy()
    {
        StartCoroutine("SpawnEnemyCoroutine");

    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        for (int i = 0; i < enemySpawnCnt; ++i)
        {
            GameObject enemyGo = Instantiate(enemyPrefab, this.transform);
            Enemy enemy = enemyGo.GetComponent<Enemy>();
            enemy.Init(GetRandomPos(), playerTr, targetPos);

            yield return new WaitForSeconds(1f);
        }
    }

    
    private Vector3 GetRandomPos()
    {
        if (outerCircleRad < innerCircleRad)
        {
            Debug.LogError("OuterCircleRad must bigger than InnerCircleRad");
            Debug.Break();
            return Vector3.zero;
        }

        float rndLength = Random.Range(outerCircleRad, innerCircleRad);
        float rndAngle = Random.Range(-180, 180);
        return new Vector3(rndLength * Mathf.Cos(rndAngle), 0f, rndLength * Mathf.Sin(rndAngle));
    }


    [SerializeField]
    private GameObject enemyPrefab = null;
    [SerializeField]
    private int enemySpawnCnt = 5;
    [SerializeField]
    private float outerCircleRad = 15f;
    [SerializeField]
    private float innerCircleRad = 14f;

    private GameManager gm = null;
    private Transform playerTr = null;
    private Vector3 targetPos = Vector3.zero;
}
