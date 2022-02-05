using UnityEngine;

public class CorridorView : MonoBehaviour
{
    [SerializeField] private int _corridorLenght;
    private float _speed;

    public int CorridorLenght
    {
        get
        {
            return _corridorLenght;
        }
    }

    public void Init(float speed)
    {
        _speed = speed;
    }

    public void SpeedChange(float speed)
    {
        _speed = speed;
    }

    public void FixedUpdate()
    {
        transform.position += Vector3.forward * -_speed;
        if (transform.position.z + _corridorLenght <= 0)
        {
            transform.position = new Vector3(0, 0, _corridorLenght);
        }
    }

    private void OnDestroy()
    {
        
    }

}