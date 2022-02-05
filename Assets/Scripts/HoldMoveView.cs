using JoostenProductions;
using UnityEngine;

public class HoldMoveView : MonoBehaviour
{
    [SerializeField] private float _speed=1f;
    private SubscriptionProperty<float> _leftMove;
    private SubscriptionProperty<float> _rightMove;

    Vector3 direction;
    Vector2 startPos = new Vector3();
    bool endTouch;


    public void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove)
    {
        _leftMove = leftMove;
        _rightMove = rightMove;

        UpdateManager.SubscribeToUpdate(OnUpdate);
    }

    private void OnUpdate()
    {
        if (Input.touchCount > 0)
        {

            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case (TouchPhase.Moved):
                    direction = touch.position - startPos;
                    break;
                case TouchPhase.Ended:
                    direction = new Vector3(0, 0, 0);
                    endTouch = true;
                    break;
            }
        }

        Move();
    }

    private void Move()
    {
        if (direction.x < -50)
            _leftMove.Value = -_speed;
        else if (direction.x > 50)
            _rightMove.Value = _speed;
        if (endTouch)
        {
            endTouch = false;
        }
    }

    void OnDestroy()
    {
        UpdateManager.UnsubscribeFromUpdate(OnUpdate);
    }
}