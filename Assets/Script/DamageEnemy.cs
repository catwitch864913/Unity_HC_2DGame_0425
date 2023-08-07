using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : DamageBasic
{
    private DataEnemy dataEnemy;

    private void Start()
    {
        dataEnemy = (DataEnemy)data;
        print(dataEnemy.expProbability);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("ªZ¾¹"))
        {
            float damage= collision.gameObject.GetComponent<Weapon>().attack;
            Damage(damage);
           
        }

    }
    protected override void Dead()
    {
        base.Dead();
        Destroy(gameObject);

        //print("ÀH¾÷­È¡G" + Random.value);
        if (Random.value < dataEnemy.expProbability)
        {
            Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
        }
    }
}
