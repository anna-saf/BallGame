using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCountView:MonoBehaviour
{
    [SerializeField] Text _cointCountText;
    private Player _player;

    public void Init(Player player)
    {
        _player = player;
        _player.coins.SubscribeOnChange(AddCoins);
        
    }

    public void AddCoins(int coins)
    {
        _cointCountText.text = coins.ToString();
    }
}