using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public BulletParams bulletInfo;

    public GameObject owner { get; private set; }
    public string ownertag;

    private Vector2 direction;

    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        bulletInfo = GetComponentInParent<PlayerCtrl>().GetCurrentBulletType();
        direction = GetComponentInParent<PlayerCtrl>().GetShotDirection();
        ownertag = transform.parent.tag;

        Destroy(gameObject, bulletInfo.Range/bulletInfo.MoveSpeed);

        rb.velocity =  direction * bulletInfo.MoveSpeed;
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.gameObject.GetComponent<EnemyScript>().OnHit(gameObject);
        }
        else if (collision.transform.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
