using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPanel : BasePanel<PlayPanel>
{
    // 游戏场景的UI
    public CustomGUILabel scoreLabel;
    public CustomGUILabel timeLabel;
    
    public CustomGUIButton settingBut;
    public CustomGUIButton quitBut;

    public CustomGUITexture healthBk;
    public CustomGUITexture nowHealth;
    //可设置属性
    public float maxHealthLength;
    //计算时间
    private float realTime;
    private int showTime;
    //计算分数
    private int score;
    
    void Start()
    {
        healthBk.guiPos.width = maxHealthLength;
        nowHealth.guiPos.width = maxHealthLength;
        score = 0;
        
        settingBut.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        quitBut.clickEvent += () =>
        {
            QuitSurePanel.Instance.ShowMe();
            HideMe();
        };


    }
    
    void Update()
    {
        realTime += Time.deltaTime;
        showTime = (int)realTime;
        if (showTime == 0)
        {
            timeLabel.content.text = "0秒";
        }
        else
        {
            timeLabel.content.text = "";
            if (showTime/3600 > 0)
            {
                timeLabel.content.text += showTime/3600 + "时";
            }
            if(showTime%3600/60 > 0)
            {
                timeLabel.content.text += showTime%3600/60 + "分";
            }
            timeLabel.content.text += showTime%60 + "秒";
        }
    }
    /// <summary>
    /// 添加分数
    /// </summary>
    /// <param name="addScore">要添加的得分</param>
    public void AddScore(int addScore)
    {
        score += addScore;
        scoreLabel.content.text = score.ToString();
    }
    /// <summary>
    /// 更新玩家血量
    /// </summary>
    /// <param name="maxHealth">目前玩家的最大血量</param>
    /// <param name="nowHealth">当前血量</param>
    public void UpdateHealth(int maxHealth,int nowHealth)
    {
        this.nowHealth.guiPos.width = maxHealthLength * nowHealth / maxHealth;
    }

}
