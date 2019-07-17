using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private int health;

    private List<Effect> CurrentEffects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for( int i = 0; i < CurrentEffects.Count;)
        {
            //Perform effect action
            CurrentEffects[i].Update(GetComponent<EnemyScript>());

            //Remove effect if expired
            if( CurrentEffects[i].GetDuration() <= 0.0f)
            {
                CurrentEffects.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        //Destroy enemy
        if( health <= 0)
        {
            Destroy(gameObject);
        }

    }


    public void OnHit(GameObject bullet)
    {

        BulletScript bulletScript = bullet.GetComponent<BulletScript>();

        //Deal damage
        health -= bulletScript.bulletInfo.Damage;

        //Add all effects
        foreach(Effect e in bulletScript.bulletInfo.Effects)
        {
            CurrentEffects.Add(e);
        }
        //Remove bullet
        Destroy(bullet);
    }

}
