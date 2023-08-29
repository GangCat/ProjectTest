using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Enemy"))
        {
            Debug.Log("EnemyAttack");
            gameObject.SetActive(false);
        }
    }

    [SerializeField]
    private float moveSpeed = 7f;
}
