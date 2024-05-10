using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public CustomGUIButton StartButton;
    public CustomGUIButton SettingButton;
    public CustomGUIButton QuitButton;

    private void Awake()
    {
        StartButton.clickEvent += () => { SceneManager.LoadScene("PlayScene"); };

        SettingButton.clickEvent += () => { };
        
        QuitButton.clickEvent += () => { Application.Quit(); };
    }
}
