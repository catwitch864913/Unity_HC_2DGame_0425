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
        AudioClip sound = SoundManager.instance.soundPlayerHurt;
        SoundManager.instance.PlaySound(sound, 0.8f, 1.5f);
        imaHp.fillAmount = hp / hpMax;
    }
    protected override void Dead()
    {
        base.Dead();

        if (goFinal.activeInHierarchy) return;

        AudioClip sound = SoundManager.instance.soundPlayerDead;
        SoundManager.instance.PlaySound(sound, 0.8f, 1.5f);
        playerCollder.enabled = false;
        weaponSystem.Stop();
        textFinal.text = "�A�w�g���F...";
        goFinal.SetActive(true);
    }
    public void Win()
    {
        if (goFinal.activeInHierarchy) return;
        textFinal.text = "�L��";
        goFinal.SetActive(true);
    }
    
}
