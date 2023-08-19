using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
    [Header("血條")]
    public Image imaHp;
    [Header("控制系統：企鵝")]
    public PlayerCollder playerCollder;
    [Header("武器系統：瓶酒生成點")]
    public WeaponSystem weaponSystem;
    [Header("結束畫面")]
    public GameObject goFinal;
    [Header("結束標題")]
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
        textFinal.text = "你已經死了...";
        goFinal.SetActive(true);
    }
    public void Win()
    {
        textFinal.text = "過關";
        goFinal.SetActive(true);
    }
    
}
