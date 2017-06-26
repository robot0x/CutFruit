using UnityEngine;

public enum FruitType
{
    Apple,
    Lemon,
    WaterMelon,
    Bomb
}

public class Fruit : MonoBehaviour
{
    [Header("物体类型")]
    public FruitType fruitType;
    [Header("碎片预设")]
    public GameObject[] fruits;
    [Header("特效预设")]
    public GameObject[] effects;

    private bool isOk = false;

    public void OnCut()
    {
        if (isOk) { return; }
        isOk = true;

        // 碎片
        for (int i = 0; i < fruits.Length; i++)
        {
            GameObject go = Instantiate(fruits[i], transform.position, Random.rotation);
            go.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 5f, ForceMode.Impulse);
        }
        // 特效
        for (int i = 0; i < effects.Length; i++)
        {
            Instantiate(effects[i], transform.position, Quaternion.identity);
        }
        // 音效
        switch (fruitType)
        {
            case FruitType.Apple:
                AudioMgr.Instance.PlayEffect(Consts.Splat1);
                break;
            case FruitType.Lemon:
                AudioMgr.Instance.PlayEffect(Consts.Splat2);
                break;
            case FruitType.WaterMelon:
                AudioMgr.Instance.PlayEffect(Consts.Splat3);
                break;
            case FruitType.Bomb:
                AudioMgr.Instance.PlayEffect(Consts.Bomb);
                break;
            default:
                break;
        }
        // 加分
        GameControl.Instance.UpdateScore(fruitType);
        // 销毁
        Destroy(this.gameObject);
    }
}
