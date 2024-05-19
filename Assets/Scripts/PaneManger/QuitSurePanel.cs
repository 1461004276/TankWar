using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitSurePanel : BasePanel<QuitSurePanel>
{
    public CustomGUIButton sureQuitButton;
    public CustomGUIButton noQuitButton;



    void Start()
    {
        sureQuitButton.clickEvent += () =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("BeginScene");
            //退出游戏
        };
        noQuitButton.clickEvent += () =>
        {
            //继续游戏
            PlayPanel.Instance.ShowMe();
            HideMe();
            Time.timeScale = 1f;
        };
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        Time.timeScale = 0f;
    }
}
