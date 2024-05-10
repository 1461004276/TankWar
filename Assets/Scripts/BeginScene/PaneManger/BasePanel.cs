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
    public void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public void HideMe()
    {
        this.gameObject.SetActive(false);

    }
    
    
}
