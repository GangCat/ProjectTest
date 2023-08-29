using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void MovePlayer(float _h, float _v, float _moveSpeed)
    {
        moveDir = new Vector3(_h, 0f, _v).normalized;

        transform.position += moveDir * _moveSpeed * Time.deltaTime;
    }

    public void RotatePlayer(Vector3 _rotatePos)
    {
        transform.forward = _rotatePos - transform.position;
    }



    private Vector3 moveDir = Vector3.zero;
}
