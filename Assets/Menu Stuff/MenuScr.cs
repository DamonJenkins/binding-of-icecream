using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Sprites;
using UnityEngine.UI;
public class MenuScr : MonoBehaviour
{
    public Image Control;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        ExitGame();
    }
    public void ShowCtrl()
    {
        Control.enabled = !Control.enabled;
    }
}
