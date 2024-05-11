using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    
    private static DataManager instance = new DataManager();
    public static DataManager Instance { get => instance; }
    
    public MusicData musicData;
    
    public RankList rankInfoList;


    private DataManager()
    {
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"MusicData") as MusicData;
        if (!musicData.notFirstTime)
        {
            musicData.notFirstTime = true;
            musicData.enableMusic = true;
            musicData.enableSound = true;
            musicData.musicVolume = 1f;
            musicData.soundVolume = 1f;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "MusicData");
        }
        // 构造函数中不再加载数据
        rankInfoList = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }
    
    
    
    /// <summary>
    /// 排行榜添加数据
    /// </summary>
    /// <param name="name">名字</param>
    /// <param name="time">时间</param>
    public void AddRankInfo(string name,float time)
    {
        rankInfoList.list.Add(new RankInfo(name,time));
        //排序
        rankInfoList.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        //排序过后 移除4条以外的数据
        //从尾部往前遍历 移除每一条
        for (int i = rankInfoList.list.Count - 1; i >= 4; i--)
        {
            rankInfoList.list.RemoveAt(i);
        }
        //存储
        PlayerPrefsDataMgr.Instance.SaveData(rankInfoList, "Rank");
    }
    /// <summary>
    /// 删除所有注册表
    /// </summary>
    public void ClearAllInfo()
    {
        
        musicData.enableMusic = true;
        musicData.enableSound = true;
        musicData.musicVolume = 1f;
        musicData.soundVolume = 1f;
        MusicManager.Instance.MusicIsPlaying(DataManager.Instance.musicData.enableMusic);
        MusicManager.Instance.SoundIsPlaying(DataManager.Instance.musicData.enableSound);
        MusicManager.Instance.SetMusicVolume(DataManager.Instance.musicData.musicVolume);
        MusicManager.Instance.SetSoundVolume(DataManager.Instance.musicData.soundVolume);
        for (int i = 0; i < rankInfoList.list.Count; i++)
        {
            rankInfoList.list[i].name = "NULL";
            rankInfoList.list[i].time = 0;
        }
        PlayerPrefs.DeleteAll();
    }

    /// <summary>
    /// 开启音乐
    /// </summary>
    /// <param name="isOpen">是否开启</param>
    public void openMusic(bool isOpen)
    {
        musicData.enableMusic = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "MusicData");
    }
    /// <summary>
    /// 设置背景音乐音量
    /// </summary>
    /// <param name="volume">0到1</param>
    public void setMusicVulume(float volume)
    {
        musicData.musicVolume = volume;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "MusicData");
    }
    /// <summary>
    /// 是否开启音效
    /// </summary>
    /// <param name="isOpen"></param>
    public void openSound(bool isOpen)
    {
        musicData.enableMusic = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "MusicData");
    }
    /// <summary>
    /// 设置音效音量
    /// </summary>
    /// <param name="volume">0到1</param>
    public void setSoundVulume(float volume)
    {
        musicData.musicVolume = volume;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "MusicData");
    }

    
}
