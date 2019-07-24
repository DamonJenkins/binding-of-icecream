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
    private float forceStrength = 2.0f;
    [SerializeField]
    private float wanderTimerMax = 2.0f;
    [SerializeField]
    private float wanderTimerMin = 0.5f;
    [SerializeField]
    private Sprite[] dirSprites;

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
            rb.AddForce(targetDirection * Time.deltaTime * forceStrength, ForceMode2D.Force);
        }

        if(wanderTimer <= 0.0f)
        {
            wanderTimer = Random.Range(wanderTimerMin, wanderTimerMax);
            targetDirection = Random.value < 0.5f ? new Vector2(0.0f, 0.0f) : Random.insideUnitCircle.normalized;
        }

        if (Mathf.Abs(rb.velocity.y) > Mathf.Abs(rb.velocity.x))
        {
            if (rb.velocity.y > 0.0f)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = dirSprites[0];
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().sprite = dirSprites[1];
            }
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().sprite = dirSprites[2];
            GetComponentInChildren<SpriteRenderer>().flipX = rb.velocity.x > 0.0f;
        }

    }
}
