using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cat/Data Skill")]
public class DataSkill : ScriptableObject
{
    [Header("技能名稱")]
    public string nameSkill;
    [Header("技能圖片")]
    public Sprite skillPicture;
    [Header("技能描述")]
    public string skillDescription;
    [Header("技能等級")]
    public int skillLv;
    [Header("技能數值")]
    public float[] skillValues;
    private void OnEnable()
    {
        skillLv = 1;
    }
}
