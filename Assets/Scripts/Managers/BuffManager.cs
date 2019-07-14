using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> buffs;

    [SerializeField]
    private int _buffDropRate = 100;



    public void GetBuff(Vector3 position)
    {
        int pick = Utils.GenerateNumber(0, _buffDropRate);
        if (pick == 0)
        {
            int randomBuffIndex = Utils.GenerateNumber(0, buffs.Count);
            Instantiate(buffs[randomBuffIndex], position, Quaternion.identity);
        }
    }

    public void SetBuffDropRate(int dropRate)
    {
        this._buffDropRate = dropRate;
    }
}
