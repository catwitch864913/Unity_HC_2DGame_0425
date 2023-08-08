using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("生成間格時間"), Range(0, 10)]
    public float inverval = 3.5f;
    [Header("武器攻擊力"), Range(0, 10000)]
    public float attack = 50;
    [Header("武器預置物")]
    public GameObject prefabWeapon;

    [Header("武器的推力")]
    public Vector2 power;
    private void Awake()
    {
        InvokeRepeating("SpawnWeapon",0,inverval);
    }
    private void SpawnWeapon()
    {
        GameObject tempWeapon= Instantiate(prefabWeapon, transform.position, transform.rotation);
        Rigidbody2D rigWeapon = tempWeapon.GetComponent<Rigidbody2D>();
        rigWeapon.AddForce(power);
        tempWeapon.GetComponent<Weapon>().attack = this.attack;
    }

    public void Restart()
    {
        CancelInvoke("SpawnWeapon");
        InvokeRepeating("SpawnWeapon", 0, inverval);
    }
    public void Stop()
    {
        CancelInvoke("SpawnWeapon");
    }
}
