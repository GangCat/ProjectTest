using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : ResourceBase
{
    public override void Init()
    {
        transform.rotation = Random.rotation;
    }
}
