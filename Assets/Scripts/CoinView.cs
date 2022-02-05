using System;
using UnityEngine;

public class CoinView:MonoBehaviour
{
    [SerializeField] private float _coinHeight;
    private float _speed;
    private Player _player;

    public float CoinHeight
    {
        get
        {
            return _coinHeight;
        }
    }

    public void Init(Player player)
    {
        _player = player;
        _speed = player.speedBall.Value;
    }

    public void CorrectPosition(float xPos, float maxValForX, float zPos)
    {
        if ((Math.Abs(xPos) + _coinHeight / 2) > maxValForX)
            if (xPos < 0)
                transform.position = new Vector3(xPos + _coinHeight / 2, transform.position.y, zPos);
            else transform.position = new Vector3(xPos - _coinHeight / 2, transform.position.y, zPos);
        else transform.position = new Vector3(xPos, transform.position.y, zPos);
    }

    public void FixedUpdate()
    {
        transform.position += Vector3.forward * -_speed;
        if (transform.position.z  <= 0)
        {
            GameObject.Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            _player.coins.Value += 1;
            GameObject.Destroy(transform.gameObject);
        }
    }
}