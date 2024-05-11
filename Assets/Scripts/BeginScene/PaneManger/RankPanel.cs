using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    //关闭窗口按钮
    public CustomGUIButton CloseButton;

    public GameObject guiRoot;
    
    //排行榜数据文本控件
    public List<CustomGUILabel> NameLabels;
    public List<CustomGUILabel> TimeLabels;
    
    
    
    private void Start()
    {
        for (int i = 1; i < 5; i++)
        {
            NameLabels.Add(guiRoot.transform.Find("Name/Label" + i).GetComponent<CustomGUILabel>());
            TimeLabels.Add(guiRoot.transform.Find("Time/Label" + i).GetComponent<CustomGUILabel>());
        }
        CloseButton.clickEvent += () =>
        {
            BeginPanel.Instance.ShowMe();
            HideMe();
        };
        
        // DataManager.Instance.AddRankInfo("测试",9999f);
        //DataManager.Instance.ClearAllInfo();
        
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        updateInfo();
    }

    public void updateInfo()
    {
        Debug.Log(DataManager.Instance.rankInfoList.list.Count());
        for (int i = 0; i < DataManager.Instance.rankInfoList.list.Count(); i++)
        {
            NameLabels[i].content.text = DataManager.Instance.rankInfoList.list[i].name;
            int tempTime = (int)DataManager.Instance.rankInfoList.list[i].time;
            TimeLabels[i].content.text = "";
            if (tempTime == 0) TimeLabels[i].content.text += "NULL";
            else
            {
                //时间转换
                if ( tempTime / 3600 > 0 )
                {
                    TimeLabels[i].content.text += tempTime / 3600 + "时";
                }
                if ( tempTime % 3600 / 60 > 0 || TimeLabels[i].content.text != "")
                {
                    TimeLabels[i].content.text += tempTime % 3600 / 60 + "分";
                }
                TimeLabels[i].content.text += tempTime % 60 + "秒";
            }
        }
    }
    
}
