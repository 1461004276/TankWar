using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUIButton CloseButton;
    
    public CustomGUIToggle musicToggle;
    public CustomGUIToggle soundToggle;
    public CustomGUISlider  musicSlider;
    public CustomGUISlider soundSlider;
    
    
    private void Start()
    {
        CloseButton.clickEvent += () =>
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BeginScene"))
            {
                BeginPanel.Instance.ShowMe();
            }
            else
            {
                PlayPanel.Instance.ShowMe();
            }

            HideMe();
            Time.timeScale = 1f;
        };

        musicToggle.changeValue += DataManager.Instance.openMusic;
        musicToggle.changeValue += MusicManager.Instance.MusicIsPlaying;
        soundToggle.changeValue += DataManager.Instance.openSound;
        soundToggle.changeValue += MusicManager.Instance.SoundIsPlaying;
        musicSlider.changeValue += DataManager.Instance.setMusicVulume;
        musicSlider.changeValue += MusicManager.Instance.SetMusicVolume;
        soundSlider.changeValue += DataManager.Instance.setSoundVulume;
        soundSlider.changeValue += MusicManager.Instance.SetSoundVolume;
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        updataInfo();
        Time.timeScale = 0f;
    }

    private void updataInfo()
    {
        musicToggle.isSel = DataManager.Instance.musicData.enableMusic;
        soundToggle.isSel = DataManager.Instance.musicData.enableSound;
        musicSlider.nowValue = DataManager.Instance.musicData.musicVolume;
        soundSlider.nowValue = DataManager.Instance.musicData.soundVolume;
    }
}
