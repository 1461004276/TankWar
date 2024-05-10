using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUIButton QuitButton;

    private void Start()
    {
        QuitButton.clickEvent += () =>
        {
            BeginPanel.Instance.ShowMe();
            HideMe();
        };
        HideMe();
    }
    
}
