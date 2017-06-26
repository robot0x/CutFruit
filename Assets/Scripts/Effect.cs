using UnityEngine;

public class Effect : MonoBehaviour
{
    [Header("线条预制体")]
    public GameObject linePrefab;

    // 线条物体
    private GameObject go;
    // 线条渲染器
    private LineRenderer lineRenderer;
    // 当前数量
    private int curCnt;

    void Update()
    {
        if (!GameControl.Instance.IsStart) { return; }

        // 鼠标按下
        if (Input.GetMouseButtonDown(0))
        {
            go = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
            lineRenderer = go.GetComponent<LineRenderer>();
            curCnt = 0;
        }
        // 鼠标抬起
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(go);
        }
        // 鼠标按下期间
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            SavePosition(pos);
            OnRayCast(pos);
        }
    }

    void SavePosition(Vector3 pos)
    {
        lineRenderer.positionCount = ++curCnt;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;
        // 设置位置
        lineRenderer.SetPosition(curCnt - 1, pos);
    }

    void OnRayCast(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            // 发送消息
            hits[i].collider.gameObject.SendMessage("OnCut", SendMessageOptions.DontRequireReceiver);
        }
    }
}
