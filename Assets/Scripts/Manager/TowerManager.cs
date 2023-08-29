using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public void Init()
    {
        tower = GetComponentInChildren<Tower>();
    }

    public Vector3 GetTowerPos()
    {
        return tower.GetPos();
    }

    private Tower tower = null;
}
