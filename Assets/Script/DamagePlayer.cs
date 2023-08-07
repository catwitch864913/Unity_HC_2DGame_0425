using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
    [Header("¦å±ø")]
    public Image imaHp;
    public void Start()
    {
        Damage(300);
    }
    public override void Damage(float damage)
    {
        base.Damage(damage);
        imaHp.fillAmount = hp / hpMax;
    }
}
