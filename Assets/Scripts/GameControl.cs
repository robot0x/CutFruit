using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private static GameControl _instance;
    public static GameControl Instance { get { return _instance; } }
    void Awake() { _instance = this; }

    private bool isStart = false;
    public bool IsStart { get { return isStart; } }

    [Header("分数文本")]
    public Text scoreUI;
    [Header("开始游戏")]
    public GameObject startPanel;
    [Header("游戏结束")]
    public GameObject overPanel;

    private int score = 0;

    public void GameStart()
    {
        isStart = true;
        scoreUI.gameObject.SetActive(true);
        startPanel.SetActive(false);
    }

    void GameOver()
    {
        isStart = false;
        scoreUI.gameObject.SetActive(false);
        overPanel.SetActive(true);
        AudioMgr.Instance.PlayEffect(Consts.Finish);
    }

    public void UpdateScore(FruitType objType)
    {
        switch (objType)
        {
            case FruitType.Apple:
                score += 10;
                break;
            case FruitType.Lemon:
                score += 15;
                break;
            case FruitType.WaterMelon:
                score += 20;
                break;
            case FruitType.Bomb:
                score -= 50;
                break;
            default:
                break;
        }
        scoreUI.text = "Score : " + score;
        if (score < 0) { GameOver(); }
    }
}
