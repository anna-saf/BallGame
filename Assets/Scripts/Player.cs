using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public SubscriptionProperty<GameState> gameState;
    public SubscriptionProperty<int> gold;
    public SubscriptionProperty<int> lives;
    public SubscriptionProperty<float> speedBall;

    public Player(float speed, int gold = 0, int lives = 3)
    {
        gameState = new SubscriptionProperty<GameState>();
        this.gold = new SubscriptionProperty<int>();
        this.lives = new SubscriptionProperty<int>();
        speedBall = new SubscriptionProperty<float>();
        this.gold.Value = gold;
        speedBall.Value = speed;
    }
}
