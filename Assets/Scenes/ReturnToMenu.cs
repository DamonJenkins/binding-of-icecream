﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
	private float timer = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		timer -= Time.deltaTime;

		if (timer <= 0.0f) {
			SceneManager.LoadScene(0);
		}
    }
}
