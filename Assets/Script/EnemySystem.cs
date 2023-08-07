using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EnemySystem : MonoBehaviour
{
    [Header("�ĤH���")]
    public DataEnemy data;

    private Transform Player;
    private float timer;

    //��Υ\��A�Ψ�ø�s�I�����x�ݽd�򪺡A���U�{��
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0.3f, 0.5f);

        Gizmos.DrawSphere(transform.position, data.attackRange);
    }
    private void Awake()
    {
        Player = GameObject.Find("���Z").transform;
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
            print("<color=#f96>�i�J�����d��</color>");
            timer += Time.deltaTime;
            print($"<color=#9f4>�p�ɾ�:{timer}</Color>");
        }
    }
}
