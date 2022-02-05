using UnityEngine;
using System;
using System.Collections.Generic;

internal class CorridorController:BaseController
{
    private Player _player;
    private Transform _placeForGame;
    private Config _config;
    private CorridorView _lastView;
    private CorridorView _nextView;
    private List<CoinView> _coinsOnScene;
    private List<BombView> _bombsOnScene;

    

    public CorridorController(Player player, Transform placeForGame, Config config)
    {
        _placeForGame = placeForGame;
        _player = player;
        _config = config;

        _coinsOnScene = new List<CoinView>();
        _bombsOnScene = new List<BombView>();

        _lastView = LoadCorridorView(_placeForGame, new Vector3(0,0,0));
        _lastView.Init(_player,LoadNewCorridor);
        GenerateCoinsAndBombsOnCorridor(_lastView.CorridorWidth, _lastView.CorridorHeight,true);

        _nextView = LoadCorridorView(_placeForGame, new Vector3(0, 0, _lastView.CorridorWidth));
        _nextView.Init(_player,LoadNewCorridor);
        GenerateCoinsAndBombsOnCorridor(_nextView.CorridorWidth, _nextView.CorridorHeight,false);
    }



    public CorridorView LoadCorridorView(Transform placeForGame, Vector3 pos)
    {
        var objView = UnityEngine.Object.Instantiate(Resources.Load<GameObject>(_config.pathCorridorPrefab), pos, Quaternion.identity,placeForGame);
        AddGameObjects(objView);

        return objView.GetComponent<CorridorView>();
    }

    private void GenerateCoinsAndBombsOnCorridor(float corridorWidth, float corridorHeight, bool firstCorridor)
    {
        var minValForX = corridorHeight / 2 * (-1);
        var maxValForX = corridorHeight / 2;
        var distanceBetweenObj = 1;
        float zPos;
        float nextCorridorZPos;
        if (firstCorridor)
        {
            zPos = distanceBetweenObj * 2;
            nextCorridorZPos = 0;
        }
        else 
        { 
            zPos = distanceBetweenObj;
            nextCorridorZPos = corridorWidth;
        }


        while (zPos<=corridorWidth)
        {
            float xPos = UnityEngine.Random.Range(minValForX, maxValForX);
            int bombOrCoin = UnityEngine.Random.Range(1, 3);
            switch (bombOrCoin)
            {
                case 1:
                    var coin = LoadCoinView(_placeForGame);
                    coin.Init(_player);
                    coin.CorrectPosition(xPos, maxValForX, zPos+nextCorridorZPos);
                    _coinsOnScene.Add(coin);
                    zPos += distanceBetweenObj; 
                    break;
                case 2:
                    var bomb = LoadBombView(_placeForGame);
                    bomb.Init(_player);
                    bomb.CorrectPosition(xPos, maxValForX, zPos+nextCorridorZPos);
                    _bombsOnScene.Add(bomb);
                    zPos += distanceBetweenObj;
                    break;
            }
        }
    }

    public CoinView LoadCoinView(Transform placeForGame)
    {
        var objView = UnityEngine.Object.Instantiate(Resources.Load<GameObject>(_config.pathCoinPrefab), placeForGame, false);
        AddGameObjects(objView);
        

        return objView.GetComponent<CoinView>();
    }

    public BombView LoadBombView(Transform placeForGame)
    {
        var objView = UnityEngine.Object.Instantiate(Resources.Load<GameObject>(_config.pathBombPrefab), placeForGame, false);
        AddGameObjects(objView);

        return objView.GetComponent<BombView>();
    }

    public void LoadNewCorridor()
    {
        _lastView = _nextView;
        _nextView = LoadCorridorView(_placeForGame, new Vector3(0, 0, _lastView.CorridorWidth));
        _nextView.Init(_player, LoadNewCorridor);
        GenerateCoinsAndBombsOnCorridor(_nextView.CorridorWidth, _nextView.CorridorHeight, false);
    }
}