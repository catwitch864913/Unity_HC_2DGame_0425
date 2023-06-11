using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public Transform Player;
    private void Awake()
    {
        Player =GameObject.Find("¥øÃZ").transform;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, 0.01f);
    }
}
