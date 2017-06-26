using UnityEngine;

public class Consts
{
    public const string Background = "Background";
    public const string Bomb = "bomb";
    public const string BombExplode = "bomb_explode";
    public const string Finish = "finish";
    public const string FruitLaunch = "fruit_launch";
    public const string Splat1 = "splat1";
    public const string Splat2 = "splat2";
    public const string Splat3 = "splat3";
    public const string Swing = "swing";
}

public class AudioMgr : MonoBehaviour
{
    private static AudioMgr _instance;
    public static AudioMgr Instance { get { return _instance; } }

    // 音效播放器
    private AudioSource[] audioSource;
    private AudioSource musicSource;
    private AudioSource effectSource;

    void Awake()
    {
        _instance = this;

        // 获取音效组件
        audioSource = GetComponents<AudioSource>();
        // 第一个控制音乐
        musicSource = audioSource[0];
        // 第二个控制音效
        effectSource = audioSource[1];
    }

    // 音乐
    public void PlayMusic(string music)
    {
        musicSource.clip = Resources.Load<AudioClip>(music);
        musicSource.Play();
    }

    // 控制音乐大小
    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
    }

    // 获取音乐大小
    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    // 音效
    public void PlayEffect(string effect)
    {
        AudioClip clip = Resources.Load<AudioClip>(effect);
        effectSource.PlayOneShot(clip);
    }

    // 获取音效大小
    public float GetEffectVolume()
    {
        return effectSource.volume;
    }

    // 控制音效大小
    public void SetEffectVolume(float value)
    {
        effectSource.volume = value;
    }
}
