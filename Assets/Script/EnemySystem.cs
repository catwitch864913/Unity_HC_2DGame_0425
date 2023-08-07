using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EnemySystem : MonoBehaviour
{
    [Header("敵人資料")]
    public DataEnemy data;

    private Transform Player;
    private float timer;

    //實用功能，用來繪製碰撞器官看範圍的，輔助程式
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0.3f, 0.5f);

        Gizmos.DrawSphere(transform.position, data.attackRange);
    }
    private void Awake()
    {
        Player = GameObject.Find("企鵝").transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.position);
        print(distance);

        if (distance > data.attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, data.speed * Time.deltaTime);
        }
        else
        {
            print("<color=#f96>進入攻擊範圍</color>");
            timer += Time.deltaTime;
            print($"<color=#9f4>計時器:{timer}</Color>");
        }
    }
}
