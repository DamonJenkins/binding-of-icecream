using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private int health;

    private List<float/*Effects*/> CurrentEffects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for( int i = 0; i < CurrentEffects.Count;)
        {
            CurrentEffects[i] -= Time.deltaTime;
            if( CurrentEffects[i] <= 0.0f)
            {
                CurrentEffects.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        if( health <= 0)
        {
            Destroy(gameObject);
        }

    }


    public void OnHit(/*Get Bullet object*/)
    {
        health -= 1; //Get bullet damage
        if (false /*Bullet has effect*/)
        {
            CurrentEffects.Add(1.0f/*Bullet effect*/);
        }
        //Destroy(bullet);
    }

}
