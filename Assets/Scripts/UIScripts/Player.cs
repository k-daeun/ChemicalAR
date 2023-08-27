using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    void Start()
    {
        
    }


    void Update()
    {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    // Back Button
                    Application.Quit();
                }
                if (Input.GetKeyDown(KeyCode.Home))
                {
                    // Home Button
                }
                if (Input.GetKeyDown(KeyCode.Menu))
                {
                    // Menu Button
                }
            }

    }
}
