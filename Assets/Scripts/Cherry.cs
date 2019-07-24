using System.Collections;
//using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Cherry : Effect
{
    Vector2 force;
    Vector2 position;
    float timeleft;
    float radius = 2.2f;
    //bool boomed = false;
    public Cherry(Vector3 CherryPos,float duration) : base (duration)
    {
        position.x = CherryPos.x;
        position.y = CherryPos.y;
        timeleft = duration;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if(timeleft <= 0.05f)
        {
            OnDestroy();
        }
    }

    override public  void  OnDestroy()
    {
        // add effect
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);
        foreach (Collider2D nearbyStuff in colliders)
        {
            Rigidbody2D rb = nearbyStuff.GetComponent<Rigidbody2D>();
            if(nearbyStuff.transform.parent != null )
            {
                if(nearbyStuff.transform.parent.tag == "Enemy")
                {
                   nearbyStuff.GetComponentInParent<EnemyScript>().GotBoomed();
                   
                }
                if (nearbyStuff.transform.parent.tag == "Player")
                {
                    nearbyStuff.GetComponentInParent<PlayerCtrl>().gotBoomed();

                }


                if (position.x > nearbyStuff.transform.position.x)
                {
                    force.x = -Mathf.Sqrt(Vector2.Distance(nearbyStuff.transform.position, position));
                }
                else
                {
                    force.x = -Mathf.Sqrt(Vector2.Distance(nearbyStuff.transform.position, position));
                }
                if (position.y > nearbyStuff.transform.position.y)
                {
                    force.y = -Mathf.Sqrt(Vector2.Distance(nearbyStuff.transform.position, position));
                }
                else
                {
                    force.y = Mathf.Sqrt(Vector2.Distance(nearbyStuff.transform.position, position));
                }
                rb.AddForce(force);
            }
        }

        
        
    }
    //void Boom()
    //(

    //}
}
