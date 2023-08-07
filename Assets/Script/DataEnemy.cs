using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(menuName ="Cat/Data Enemy")]
public class DataEnemy : DataBasic
{
    [Header("掉落經驗值機率"), Range(0, 1)]
    public float expProbability;
    [Header("經驗預置物")]
    public GameObject prefabExp;
    [Header("攻擊範圍"), Range(0, 3)]
    public float attackRange = 1f;
    [Header("攻擊間隔"), Range(0, 3)]
    public float attackInterval = 1;
}
