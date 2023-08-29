using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
            }
            return instance;
        }
    }

    public void MovePlayer(float _h, float _v)
    {
        playerMng.MovePlayer(_h, _v);
    }

    public void SpawnEnemy()
    {
        enemyMng.SpawnEnemy();
    }

    public void RotatePlayer(Vector3 _pickPos)
    {
        playerMng.RotateToPickPos(_pickPos);
    }

    public void StartAttack()
    {
        playerMng.StartAttack();
    }

    public void StopAttack()
    {
        playerMng.StopAttack();
    }

    private GameManager()
    {
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        inputMng = FindAnyObjectByType<InputManager>();
        inputMng.Init();

        playerMng = FindAnyObjectByType<PlayerManager>();
        playerMng.Init();
        playerTr = playerMng.GetPlayerTransform();

        towermng = FindAnyObjectByType<TowerManager>();
        towermng.Init();
        towerPos = towermng.GetTowerPos();


        cameraMng = FindAnyObjectByType<CameraManager>();
        cameraMng.Init(playerTr);

        stageMng = FindAnyObjectByType<StageManager>();
        stageMng.Init();

        enemyMng = FindAnyObjectByType<EnemyManager>();
        enemyMng.Init(playerTr, towerPos);
    }

    private static GameManager instance = null;
    private InputManager inputMng = null;
    private PlayerManager playerMng = null;
    private CameraManager cameraMng = null;
    private StageManager stageMng = null;
    private EnemyManager enemyMng = null;
    private TowerManager towermng = null;

    private Transform playerTr = null;
    private Vector3 towerPos = Vector3.zero;
}