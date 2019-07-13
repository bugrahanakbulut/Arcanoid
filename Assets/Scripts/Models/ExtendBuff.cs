using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendBuff : Buff
{
    public override void ExecuteBuff(GameObject racket)
    {
        racket.transform.localScale += Vector3.right;
    }
}
