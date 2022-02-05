using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public SubscriptionProperty<GameState> gameState;
    public SubscriptionProperty<int> coins;
    public SubscriptionProperty<int> lives;
    public SubscriptionProperty<float> speedBall;

    public Player(float speed, int coins = 0, int lives = 3)
    {
        gameState = new SubscriptionProperty<GameState>();
        this.coins = new SubscriptionProperty<int>();
        this.lives = new SubscriptionProperty<int>();
        speedBall = new SubscriptionProperty<float>();
        this.coins.Value = coins;
        speedBall.Value = speed;
    }
}
