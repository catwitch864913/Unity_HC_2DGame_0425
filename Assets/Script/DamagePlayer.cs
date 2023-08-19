using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
    [Header("���")]
    public Image imaHp;
    [Header("����t�ΡG���Z")]
    public PlayerCollder playerCollder;
    [Header("�Z���t�ΡG�~�s�ͦ��I")]
    public WeaponSystem weaponSystem;
    [Header("�����e��")]
    public GameObject goFinal;
    [Header("�������D")]
    public TextMeshProUGUI textFinal;
    public void Start()
    {
        //Damage(300);
    }
    public override void Damage(float damage)
    {
        base.Damage(damage);
        imaHp.fillAmount = hp / hpMax;
    }
    protected override void Dead()
    {
        base.Dead();
        playerCollder.enabled = false;
        weaponSystem.Stop();
        textFinal.text = "�A�w�g���F...";
        goFinal.SetActive(true);
    }
    public void Win()
    {
        textFinal.text = "�L��";
        goFinal.SetActive(true);
    }
    
}
