using System.Collections;
using UnityEngine;

public class MainCamView:MonoBehaviour
{
    private Vector3 offset;
    private Transform _startCamTransform;

    private void Start()
    {
        _startCamTransform = transform;
    }

    public void Move(Transform ballPos)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, ballPos.position.z + offset.z);
    }

    public void GetOffset(Transform ballPos)
    {
        offset = transform.position - ballPos.position;
    }

    public void GoToStartPos()
    {
        transform.position = _startCamTransform.position;
    }
}