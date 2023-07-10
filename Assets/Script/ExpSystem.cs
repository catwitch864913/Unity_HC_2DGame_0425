using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ExpSystem : MonoBehaviour
{
    [Header("移動速度"),Range(0,10)]
    public float speed = 3.5f;
    [Header("被吃掉的距離"), Range(0, 3)]
    public float distanceEat = 1f;
    [Header("經驗值"), Range(0, 500)]
    public float exp = 30;

    private Transform Player;
    private LevelManager levelManager;

    private void Awake()
    {
        Player = GameObject.Find("企鵝").transform;
        levelManager = Player.GetComponent<LevelManager>();
    }
    void Start()
    {
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed*Time.deltaTime);

        if (Vector3.Distance(transform.position, Player.position) < distanceEat)
        {
            levelManager.AddExp(exp);
            Destroy(gameObject);
        }
    }
}
