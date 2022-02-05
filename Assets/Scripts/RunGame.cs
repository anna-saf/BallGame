using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGame : MonoBehaviour
{
    //Задания - привязать камеру к мячу, как только он появляется на сцене. Так же отвязывать, когда мяча нет
    [SerializeField] private float _startSpeed;
    [SerializeField] private int _startGold;
    [SerializeField] private int _startLives;
    [SerializeField] private Transform _placeForUI;
    [SerializeField] private Transform _placeForGame;
    [SerializeField] private MainCamView _mainCam;
    private MainController _mainController;
    private Player _player;
    private Config _config;

    private void Awake()
    {
        
        _config = new Config();
        _player = new Player(_startSpeed, _startGold, _startLives);
        _player.gameState.Value = GameState.Menu;
        _mainController = new MainController(_placeForUI, _player, _config, _placeForGame, _mainCam);
    }
}
