using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public void Init()
    {
        gm = GameManager.Instance;
        playerMove = GetComponentInChildren<PlayerMovement>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
        playerAttack.Init();
    }

    public void MovePlayer(float _h, float _v)
    {
        playerMove.MovePlayer(_h, _v, moveSpeed);
    }

    public Transform GetPlayerTransform()
    {
        return playerMove.transform;
    }

    public void RotateToPickPos(Vector3 _pickPos)
    {
        playerMove.RotatePlayer(_pickPos);
    }

    public void StartAttack()
    {
        playerAttack.StartAttack();
    }

    public void StopAttack()
    {
        playerAttack.StopAttack();
    }


    [SerializeField]
    private float moveSpeed = 0;

    private GameManager gm = null;
    private PlayerMovement playerMove = null;
    private PlayerAttack playerAttack = null;
}
