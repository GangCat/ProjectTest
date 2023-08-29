using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public void Init()
    {
        weapon = GetComponentInChildren<PlayerWeapon>();
        weapon.Init();
    }

    public void StartAttack()
    {
        StartCoroutine("AttackCoroutine");
    }

    public void StopAttack()
    {
        StopCoroutine("AttackCoroutine");
    }

    private IEnumerator AttackCoroutine()
    {
        yield return null;

        while (true)
        {
            weapon.Attack();

            isAttack = true;

            yield return new WaitForSeconds(attackRate);
        }
    }

    [SerializeField]
    private float attackRate = 1f;

    private PlayerWeapon weapon = null;
    private bool isAttack = false;
}