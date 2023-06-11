using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cat/Data Basic")]
public class DataBasic : ScriptableObject
{
    [Header("��q"),Range(0,10000)]
    public float hp;
    [Header("�����O"), Range(0, 1000)]
    public float attack;
    [Header("�t��"), Range(0, 100)]
    public float speed;
}
