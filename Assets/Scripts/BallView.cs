using System.Collections;
using UnityEngine;

public class BallView : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    private Rigidbody _ballRigit;
    private MainCamView _mainCam;
    private SubscriptionProperty<float> _leftMove;
    private SubscriptionProperty<float> _rightMove;

    [SerializeField] private HoldMoveView _moveView;
    private float _speed;

    public void Awake()
    {
        _ballRigit = _ball.GetComponent<Rigidbody>();

        _leftMove = new SubscriptionProperty<float>();
        _rightMove = new SubscriptionProperty<float>();
        _leftMove.SubscribeOnChange(HorizontalMove);
        _rightMove.SubscribeOnChange(HorizontalMove);
        _moveView.Init(_leftMove, _rightMove);

    }

    public void HorizontalMove(float value)
    {
        _ballRigit.AddForce(Vector3.right * value, ForceMode.Acceleration);
    }

    /*    public void Init()
        {
            _leftMove.SubscribeOnChange(HorizontalMove);
            _rightMove.SubscribeOnChange(HorizontalMove);*//*
            _speed = speed;
            _mainCam = mainCam;*//*
            _moveView.Init(_leftMove, _rightMove);
        }*/
    /*
        public void SpeedChange(float speed)
        {
            _speed = speed;
        }*/



    /*public void FixedUpdate()
    {
        _ballRigit.AddForce(Vector3.forward * _speed, ForceMode.Force);
        _mainCam.Move(transform);
        *//*if (_startPos != transform.position)
        {
            
            _startPos = transform.position;
        }*//*
    }*/

}