using UnityEngine;

public class Live:MonoBehaviour
{
    public void OnDestroy()
    {
        Object.Destroy(transform);
    }
}