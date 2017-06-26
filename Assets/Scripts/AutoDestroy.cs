using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Header("销毁时间")]
    [Range(1.0f, 5.0f)]
    public float destroyTime = 3.0f;

    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }
}
