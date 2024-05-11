using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankInfo
{
    public string name;
    public float time;

    public RankInfo()
    {
        name = "NULL";
        time = 0f;
    }
    
    public RankInfo(string name, float time)
    {
        this.name = name;
        this.time = time;
    }
    
}

public class RankList
{
    public List<RankInfo> list;
}
