using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollder : MonoBehaviour
{
    [Range(0, 10)]
    public float moveSpeed = 3.5f;
    public Rigidbody2D rb;
    public Animator ani;
    [Header("¶]¨B°Ñ¼Æ")]
    public string Run = "Walk";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
    }
    private void Move()
    {
        float a = Input.GetAxis("Horizontal");
        float b = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(a, b) * moveSpeed;
        ani.SetBool(Run, a != 0 || b != 0);
    }
}
