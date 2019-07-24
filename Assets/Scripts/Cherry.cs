using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Cherry : Effect
{
    string cherryName;
    int cherryDamage; 
    float cherryRadius;
    public Cherry(string _cherryName, int _cherryDamage, float _cherryRadius, float duration) : base (duration)
    {
        cherryName = _cherryName;
        cherryDamage = _cherryDamage;
        cherryRadius = _cherryRadius;
    }

    public override void OnDestroy()
    {
        Vector3 self = GameObject.Find(cherryName).transform.position;
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if( Vector3.Distance(self, enemy.transform.position) < cherryRadius)
            {
                enemy.GetComponent<EnemyScript>().DealDamage(cherryDamage);
            }
        }

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (Vector3.Distance(self, player.transform.GetChild(0).transform.position) < cherryRadius)
            {
                player.GetComponent<PlayerCtrl>().DealDamage(cherryDamage);
            }
        }
    }

}
