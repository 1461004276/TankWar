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

    
    //注册按钮事件放在start中执行，因为awake阶段是获取单例实例的时候，如果注册事件在start之前，会报错空引用
    private void Start()
    {
        StartButton.clickEvent += () => { SceneManager.LoadScene("PlayScene"); };

        SettingButton.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        
        QuitButton.clickEvent += () => { Application.Quit(); };
    }
}
