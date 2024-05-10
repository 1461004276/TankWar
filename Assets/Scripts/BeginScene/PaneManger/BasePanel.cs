using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    private static T instance ;

    public static T Instance
    {
        get { return instance;}
    }

    private void Awake()
    {
        //在刚开始获取一下引用，要不会导致调用子类空引用
        instance = this as T;
    }

    public void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public void HideMe()
    {
        this.gameObject.SetActive(false);

    }
    
    
}
