using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cat/Data Enemy")]
public class DataEnemy : DataBasic
{
    [Header("掉落經驗值機率"), Range(0, 1)]
    public float expProbability;
    [Header("經驗預置物")]
    public GameObject prefabExp;
}
