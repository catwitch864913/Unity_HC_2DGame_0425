using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("�g���")]
    public Image imgExp;
    [Header("��r����")]
    public TextMeshProUGUI textLv;
    [Header("��r�g���")]
    public TextMeshProUGUI textExp;

    private int lv = 1;
    private float exp = 0;

    public float[] expNeeds = { 100, 200, 300 };
    //private void Start()
    //{
    //    //AddExp(50);
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print($"<color=#6699ff>{collision.name}</color>");

        if (collision.name.Contains("�g��y"))
        {
            collision.GetComponent<ExpSystem>().enabled = true;
        }
    }
    public void AddExp(float exp)
    {
        this.exp += exp;
        textExp.text = this.exp + "/100";
        imgExp.fillAmount = this.exp / 100;
    }
}
