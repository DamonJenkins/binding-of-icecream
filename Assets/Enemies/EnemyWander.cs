using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{

    private Rigidbody2D rb;
    private Transform playerTransform;
    private Vector2 targetDirection;
    private float wanderTimer;
    [SerializeField]
    private float MoveSpeed = 2.0f;
    [SerializeField]
    private float wanderTimerMax = 2.0f;
    [SerializeField]
    private float wanderTimerMin = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        targetDirection = Random.insideUnitCircle.normalized;
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("PlayerSprite").transform;
        wanderTimer = Random.Range(wanderTimerMin, wanderTimerMax);
    }

    // Update is called once per frame
    void Update()
    {
        wanderTimer -= Time.deltaTime;

        if (rb.velocity.magnitude > MoveSpeed)
        {
            rb.velocity = targetDirection * MoveSpeed;
        }
        else
        {
            rb.AddForce(targetDirection * Time.deltaTime * 0.1f, ForceMode2D.Force);
        }

        if(wanderTimer <= 0.0f)
        {
            wanderTimer = Random.Range(wanderTimerMin, wanderTimerMax);
            targetDirection = Random.value < 0.5f ? new Vector2(0.0f, 0.0f) : Random.insideUnitCircle.normalized;
        }

    }
}
