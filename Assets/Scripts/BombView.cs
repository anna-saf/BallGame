using System;
using UnityEngine;

public class BombView : MonoBehaviour
{
    [SerializeField] private float _bombHeight;
    private float _speed;
    private Player _player;

    public float BombHeight
    {
        get
        {
            return _bombHeight;
        }
    }

    public void Init(Player player)
    {
        _player = player;
        _speed = player.speedBall.Value;
    }

    public void CorrectPosition(float xPos, float maxValForX, float zPos)
    {
        if ((Math.Abs(xPos) + _bombHeight / 2) > maxValForX)
            if (xPos < 0)
                transform.position = new Vector3(xPos + _bombHeight / 2, transform.position.y, zPos);
            else transform.position = new Vector3(xPos - _bombHeight / 2, transform.position.y, zPos);
        else transform.position = new Vector3(xPos, transform.position.y, zPos);
    }

    public void FixedUpdate()
    {
        transform.position += Vector3.forward * -_speed;
        if (transform.position.z <= 0)
        {
            GameObject.Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            _player.lives.Value += 1;
            GameObject.Destroy(transform.gameObject);
        }
    }
}