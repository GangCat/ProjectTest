using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public void Init()
    {
        projectileSpawn = GetComponentInChildren<PlayerProjectileSpawn>();
    }
    public void Attack()
    {
        Instantiate(playerWeaponProjectile, projectileSpawn.GetPos(), projectileSpawn.GetRot());
    }

    [SerializeField]
    private GameObject playerWeaponProjectile = null;

    private PlayerProjectileSpawn projectileSpawn = null;
}
