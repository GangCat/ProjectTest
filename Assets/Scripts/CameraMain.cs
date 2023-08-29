using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public void Init(Transform _playerTr)
    {
        playerTr = _playerTr;
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = playerTr.position + offset;
    }

    [SerializeField]
    private Vector3 offset = Vector3.zero;

    private Transform playerTr = null;
}
