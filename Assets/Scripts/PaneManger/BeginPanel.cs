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
    public CustomGUIButton RankButton;
    public CustomGUIButton ResetButton;

    
    //注册按钮事件放在start中执行，因为awake阶段是获取单例实例的时候，如果注册事件在start之前，会报错空引用
    private void Start()
    {
        
        MusicManager.Instance.MusicIsPlaying(DataManager.Instance.musicData.enableMusic);
        MusicManager.Instance.SoundIsPlaying(DataManager.Instance.musicData.enableSound);
        MusicManager.Instance.SetMusicVolume(DataManager.Instance.musicData.musicVolume);
        MusicManager.Instance.SetSoundVolume(DataManager.Instance.musicData.soundVolume);

        
        StartButton.clickEvent += () => { SceneManager.LoadScene("PlayScene"); };

        SettingButton.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        
        QuitButton.clickEvent += () => { Application.Quit(); };
        
        RankButton.clickEvent += () =>
        {
            RankPanel.Instance.ShowMe();
            HideMe();
        };

        ResetButton.clickEvent += () => { DataManager.Instance.ClearAllInfo(); };
    }
}
