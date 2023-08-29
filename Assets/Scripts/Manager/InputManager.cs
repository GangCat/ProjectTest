using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    public void Init()
    {
        gm = GameManager.Instance;
    }

    private void Update()
    {
        MoveInput();
        SpawnEnemyInput();
        PickingInput();
    }

    private void MoveInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        gm.MovePlayer(h, v);
    }

    private void SpawnEnemyInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            gm.SpawnEnemy();
    }

    private void PickingInput()
    {
        if (Input.GetMouseButtonDown(0))
            gm.StartAttack();
        else if (Input.GetMouseButton(0))
        {
            Vector3 pickPoint = Vector3.zero;
            Picking("Floor", ref pickPoint);
            gm.RotatePlayer(pickPoint);
        }
        else if (Input.GetMouseButtonUp(0))
            gm.StopAttack();
    }

    public static bool Picking(string _tag, ref Vector3 _point)
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, LayerMask.GetMask("Floor")))
        {
            if (hit.transform.CompareTag(_tag))
            {
                _point = hit.point;
                return true;
            }
        }
        return false;
    }




    private GameManager gm = null;
}