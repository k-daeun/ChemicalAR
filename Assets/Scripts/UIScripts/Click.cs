using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public GameObject ButtonPanel;
    public Button settingButton;
    private bool PanelActive = true;

    void Start()
    {
        
    }
    public void ButtonController()
    {
        if (PanelActive)
        {
            ButtonPanel.SetActive(false);
            PanelActive = false;
        }
        else
        {
            ButtonPanel.SetActive(true);
            PanelActive = true;
        }
    }
}