using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    private Transform playerTransform;
    private Rigidbody2D rb;
    [SerializeField]
    private float MoveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("PlayerSprite").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (playerTransform.position - transform.position).normalized * MoveSpeed;
    }
}
