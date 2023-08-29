using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public void Init(Transform _playerTr)
    {
        gm = GameManager.Instance;
        camMain = GetComponentInChildren<CameraMain>();
        camMain.Init(_playerTr);
    }

    private GameManager gm = null;
    private CameraMain camMain = null;
}
