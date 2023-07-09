using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ExpSystem : MonoBehaviour
{
    [Header("���ʳt��"),Range(0,10)]
    public float speed = 3.5f;
    private Transform Player;

    void Start()
    {
        Player = GameObject.Find("���Z").transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed*Time.deltaTime);
    }
}
