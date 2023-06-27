using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : DamageBasic
{
    public GameObject prefabDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("ชZพน"))
        {
            Damage(50);
            Instantiate(prefabDamage, transform.position, Quaternion.identity);
        }

    }
}
