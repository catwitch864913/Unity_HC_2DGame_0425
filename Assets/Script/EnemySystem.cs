using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EnemySystem : MonoBehaviour
{
    [Header("�ĤH���")]
    public DataEnemy data;

    private Transform Player;
    private void Awake()
    {
        Player =GameObject.Find("���Z").transform;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, data.speed*Time.deltaTime);
    }
}
