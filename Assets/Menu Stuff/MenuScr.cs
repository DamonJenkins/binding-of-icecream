using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Sprites;
using UnityEngine.UI;
public class MenuScr : MonoBehaviour
{
    public GameObject Control;
    // Start is called before the first frame update
    public KeyCode Return;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Return))
        {
            Control.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ShowCtrl()
    {
        Control.SetActive(true);
    }

}
