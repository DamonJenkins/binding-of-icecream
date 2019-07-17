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
    public int guntype = 1;

}

public class PlayerCtrl : MonoBehaviour
{
    public CharaData playerdata;
    public InputData m_Input;
    //Shoot
    public BulletTest Bullet;
  
    // public GameObject Bullet1;
    //public GameObject Bullet2;
    private float nextFire = 0.4f;
    private float myTime = 0.0F;
    public float fireDelta = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //void switchGun(int gun);
   
    void FireBullet(KeyCode dir,int ammo)
    {
        // CREATE
        var bullet = Instantiate(Bullet, transform.position, transform.rotation);

        // DIRECTION
        Vector2 direction = Vector2.right;
        if (dir == m_Input.ShootR)
        {
            direction = Vector2.right;
        }
        else if (dir == m_Input.ShootL)
        {
            direction = Vector2.left;
        }
        else if (dir == m_Input.ShootUp)
        {
            direction = Vector2.up;
        }
        else if (dir == m_Input.ShootDown)
        {
            direction = Vector2.down;
        }




        // CREATE
        bullet.Create(this.gameObject, direction);

        // NEXT FIRE
        nextFire = fireDelta;
        myTime = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        //switch gun
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchGun(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchGun(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            switchGun(3);
        }
        //Shoot
        myTime = myTime + Time.deltaTime;
      
            // SHOOT
            if (Input.GetKeyDown(m_Input.ShootR) && myTime > nextFire)
            {
            FireBullet(m_Input.ShootR, 1);
            
            }

        if (Input.GetKeyDown(m_Input.ShootL) && myTime > nextFire)
        {
            FireBullet(m_Input.ShootL, 1);

        }
        if (Input.GetKeyDown(m_Input.ShootUp) && myTime > nextFire)
        {
            FireBullet(m_Input.ShootUp, 1);
        }
        if (Input.GetKeyDown(m_Input.ShootDown) && myTime > nextFire)
        {

            FireBullet(m_Input.ShootDown, 1);
        }

    }

    void switchGun(int gun)
    {

        if (gun == 1)
        {
            //pistol
            playerdata.dmg = 2.0f;
            fireDelta = 0.4f;
            print("pistol");
        }
        if (gun == 2)
        {
            //machineGun
            playerdata.dmg = 1.0f;
            fireDelta = 0.2f;
            print("machinegun");
        }
        if (gun == 3)
        {
            //sniper
            playerdata.dmg = 9.5f;
            fireDelta = 1.6f;
            print("sniper");
        }
    }

}
