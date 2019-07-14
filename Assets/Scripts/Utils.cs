using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static int GenerateNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
}
