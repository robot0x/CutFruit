using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static Spawner _instance;
    public static Spawner Instance { get { return _instance; } }
    void Awake() { _instance = this; }

    [Header("最大数量")]
    [Range(1, 5)]
    public int maxCnt = 3;
    [Header("炸弹概率")]
    [Range(1, 100)]
    public int bombRate = 50;
    [Header("生成时间")]
    [Range(1.0f, 5.0f)]
    public float spawnTime = 3.0f;
    [Header("水果预设")]
    public GameObject[] fruits;
    [Header("炸弹预设")]
    public GameObject bomb;

    private int i = 0;
    private float timer = 0;

    void Update()
    {
        if (!GameControl.Instance.IsStart) { return; }

        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            Spawn();
            timer = 0;
        }
    }

    // 生成水果或炸弹
    public void Spawn()
    {
        // 水果数量
        int cnt = Random.Range(0, maxCnt) + 1;
        for (i = 0; i < cnt; i++)
        {
            SpawnGo(true);
            AudioMgr.Instance.PlayEffect(Consts.FruitLaunch); // 音效
        }
        // 炸弹概率
        int random = Random.Range(0, 100);
        if (random <= bombRate)
        {
            SpawnGo(false);
            AudioMgr.Instance.PlayEffect(Consts.BombExplode); // 音效
        }
    }

    void SpawnGo(bool isFruit)
    {
        float x = Random.Range(-8.0f, 8.0f);
        float y = transform.position.y;
        float z = i * -2; // 防止碰撞
        GameObject go = null;
        if (isFruit)
        {
            int type = Random.Range(0, fruits.Length);
            go = Instantiate(fruits[type], new Vector3(x, y, z), Random.rotation);
        }
        else
        {
            go = Instantiate(bomb, new Vector3(x, y, z), Random.rotation);
        }
        go.transform.SetParent(this.transform);
        float vx = -x * Random.Range(0.2f, 0.8f); // 反向
        float vy = -Physics.gravity.y * Random.Range(0.8f, 1.2f);
        float vz = 0;
        go.GetComponent<Rigidbody>().velocity = new Vector3(vx, vy, vz);
    }
}
