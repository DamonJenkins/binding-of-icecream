using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class InputData
{
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;

    public KeyCode Jump;
    public KeyCode ShootR;
    public KeyCode ShootL;
    public KeyCode ShootUp;
    public KeyCode ShootDown;

}

[System.Serializable]
public class CharaData
{

    //public int charaset;
    public float hp = 500;
    public float dmg;
    public float spd;
    

}

public class PlayerCtrl : MonoBehaviour
{
    public InputData m_Input;
    //Shoot
    public BulletTest Bullet;
   // public GameObject Bullet1;
    //public GameObject Bullet2;
    private float nextFire = 0.3f;
    private float myTime = 0.0F;
    public float fireDelta = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Shoot
        myTime = myTime + Time.deltaTime;
      
            // SHOOT
            if (Input.GetKeyDown(m_Input.ShootR) && myTime > nextFire)
            {
                // CREATE
                var bullet = Instantiate(Bullet, transform.position, transform.rotation);

                // DIRECTION
                Vector2 direction = Vector2.right;
                

           

                // CREATE
                bullet.Create(this.gameObject, direction);

                // NEXT FIRE
                nextFire = fireDelta;
                myTime = 0.0f;
            
            }

        if (Input.GetKeyDown(m_Input.ShootL) && myTime > nextFire)
        {
            // CREATE
            var bullet = Instantiate(Bullet, transform.position, transform.rotation);

            // DIRECTION
            Vector2 direction = Vector2.left;




            // CREATE
            bullet.Create(this.gameObject, direction);

            // NEXT FIRE
            nextFire = fireDelta;
            myTime = 0.0f;

        }
        if (Input.GetKeyDown(m_Input.ShootUp) && myTime > nextFire)
            {
               
                var bullet = Instantiate(Bullet, transform.position, transform.rotation);

            

                // CREATE
                Vector2 direction = Vector2.up;
                bullet.Create(this.gameObject, direction);

                // NEXT FIRE
                nextFire = fireDelta;
                myTime = 0.0f;
            }
            if (Input.GetKeyDown(m_Input.ShootDown) && myTime > nextFire)
            {
               
                var bullet = Instantiate(Bullet, transform.position, transform.rotation);

           

                // CREATE
                Vector2 direction = Vector2.down;
                bullet.Create(this.gameObject, direction);

                // NEXT FIRE
                nextFire = fireDelta;
                myTime = 0.0f;
            }

        }
    
}
