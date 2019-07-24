using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Effect
{
    int cherryDamage; 
    float cherryRadius;
    public Cherry(GameObject owner, int _cherryDamage, float _cherryRadius, float duration) : base (duration, owner)
    {
        cherryDamage = _cherryDamage;
        cherryRadius = _cherryRadius;
    }

    public Cherry(Cherry other) : base(other.GetDuration(), other.GetOwner())
    {
        cherryDamage = other.cherryDamage;
        cherryRadius = other.cherryRadius;
    }

   

    public void SetCherryDamage(int _cherryDamage)
    {
        cherryDamage = _cherryDamage;
    }

    public void SetCherryRadius(float _cherryRadius)
    {
        cherryRadius = _cherryRadius;
    }

    

    public int GetCherryDamage()
    {
        return cherryDamage;
    }

    public float GetCherryRadius()
    {
        return cherryRadius;
    }

    public override void OnDestroy()
    {
        Vector3 self = owner.transform.position;
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if( Vector3.Distance(self, enemy.transform.position) < cherryRadius)
            {
                enemy.GetComponent<EnemyScript>().DealDamage(cherryDamage);
            }
        }

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player.transform.childCount > 0)
            {
                if (Vector3.Distance(self, player.transform.GetChild(0).transform.position) < cherryRadius)
                {
                    player.GetComponent<PlayerCtrl>().DealDamage(cherryDamage);
                }
            }
        }
    }

}
