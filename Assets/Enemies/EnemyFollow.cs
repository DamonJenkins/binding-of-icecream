using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    private Transform playerTransform;
    private Rigidbody2D rb;
    [SerializeField]
    private float MoveSpeed = 2.0f;
    [SerializeField]
    private Sprite[] dirSprites;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("PlayerSprite").transform;
    }

    // Update is called once per frame
    void Update()
    {                                             //Offset to fix wall collisions
        rb.velocity = (playerTransform.position + new Vector3(0.1f, 0.1f) - transform.position).normalized * MoveSpeed;

        if( Mathf.Abs(rb.velocity.y) > Mathf.Abs(rb.velocity.x))
        {
            if(rb.velocity.y > 0.0f)
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
            GetComponentInChildren<SpriteRenderer>().flipX = rb.velocity.x < 0.0f;
        }
    }
}
