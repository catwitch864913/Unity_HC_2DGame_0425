using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(menuName ="Cat/Data Enemy")]
public class DataEnemy : DataBasic
{
    [Header("�����g��Ⱦ��v"), Range(0, 1)]
    public float expProbability;
    [Header("�g��w�m��")]
    public GameObject prefabExp;
    [Header("�����d��"), Range(0, 3)]
    public float attackRange = 1f;
    [Header("�������j"), Range(0, 3)]
    public float attackInterval = 1;
}
