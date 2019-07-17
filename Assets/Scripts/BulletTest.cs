using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    
    public int bspeed = 8;
    private int a = 0;
    private int b = 1;


    public GameObject owner { get; private set; }


    private Vector2 direction;

    public Rigidbody2D rb;
    public float speed = 8f;
    public float lifetime = 1f;

    public void Create(GameObject owner, Vector2 direction)
    {
        this.owner = owner;
        this.direction = direction;
    }

    // Use this for initialization
    void Start()
    {

      



        Destroy(this.gameObject, lifetime);

        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D c)
    {

        Debug.Log("BULLET COLLIDE!!!!!");

        if (c.gameObject == this.owner)
            return;

        GameObject.Destroy(this.gameObject);

        
    }
}
