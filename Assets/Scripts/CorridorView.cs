using UnityEngine;
using UnityEngine.Events;

public class CorridorView : MonoBehaviour
{
    [SerializeField] private float _corridorWidth;
    [SerializeField] private float _corridorHeight;
    private float _speed;
    private UnityEvent _loadNewCorridor;

    private void Awake()
    {
        _loadNewCorridor = new UnityEvent();
    }

    public float CorridorWidth
    {
        get
        {
            return _corridorWidth;
        }
    }

    public float CorridorHeight
    {
        get
        {
            return _corridorHeight;
        }
    }

    public void Init(Player player, UnityAction loadNewCorridor)
    {
        _speed = player.speedBall.Value;
        _loadNewCorridor.AddListener(loadNewCorridor);
    }

    public void SpeedChange(float speed)
    {
        _speed = speed;
    }

    public void FixedUpdate()
    {
        transform.position += Vector3.forward * -_speed;
        if (transform.position.z + _corridorWidth <= 0)
        {
            _loadNewCorridor.Invoke();
            GameObject.Destroy(transform.gameObject);
            //transform.position = new Vector3(0, 0, _corridorLenght);
        }
    }

    private void OnDestroy()
    {
        
    }

}