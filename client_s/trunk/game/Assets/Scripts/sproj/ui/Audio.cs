using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour
{
    public AudioSource _soundSource;
    // Use this for initialization
    void Start()
    {
        //获取音乐控件
        _soundSource = GetComponent<AudioSource>();
        //动态加载音乐
        _soundSource.clip = (AudioClip)Resources.Load("ice_fire", typeof(AudioClip));
        //设置音乐音量
        _soundSource.volume = 0.5f;
        //设置3D音效的最小距离
        _soundSource.minDistance = 40;
        //设置3D音效的最大距离
        _soundSource.maxDistance = 40;
        //设置循环播放
        _soundSource.loop = true;
        //设置游戏开始播放音乐
        _soundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 暂停播放
    /// </summary>
    public void pause()
    {
        _soundSource.Pause();
    }
    /// <summary>
    /// 恢复播放
    /// </summary>
    public void UnPause()
    {
        _soundSource.UnPause();
    }
}
