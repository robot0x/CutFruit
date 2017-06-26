using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("开始按钮")]
    public Button playBtn;
    [Header("音量按钮")]
    public Button soundBtn;
    [Header("音量图片")]
    public Image soundImg;
    [Header("返回按钮")]
    public Button returnBtn;

    public Sprite sound1Sprite;
    public Sprite sound2Sprite;
    private bool isMute = false;

    void Start()
    {
        playBtn.onClick.AddListener(delegate { OnPlayBtnClick(); });
        soundBtn.onClick.AddListener(delegate { OnSoundBtnClick(); });
        returnBtn.onClick.AddListener(delegate { OnReturnBtnClick(); });
    }

    void OnPlayBtnClick()
    {
        GameControl.Instance.GameStart();
    }

    void OnSoundBtnClick()
    {
        if (isMute) // 当前开启音量
        {
            AudioMgr.Instance.SetMusicVolume(0.5f);
            soundImg.sprite = sound1Sprite;
            isMute = false;
        }
        else // 当前关闭音量
        {
            AudioMgr.Instance.SetMusicVolume(0f);
            soundImg.sprite = sound2Sprite;
            isMute = true;
        }
    }

    void OnReturnBtnClick()
    {
        SceneManager.LoadScene(0);
    }
}
