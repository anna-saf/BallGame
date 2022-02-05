using UnityEngine;

internal class CorridorController:BaseController
{
    private Player _player;
    private Transform _placeForGame;
    private Config _config;
    private CorridorView _lastView;
    private CorridorView _nextView;

    private float CameraVisibleZoneEnd;

    public CorridorController(Player player, Transform placeForGame, Config config)
    {
        _placeForGame = placeForGame;
        _player = player;
        _config = config;
        _lastView = LoadCorridorView(_placeForGame, new Vector3(0,0,0));
        _lastView.Init(_player.speedBall.Value);
        
        _nextView = LoadCorridorView(_placeForGame, new Vector3(0, 0, _lastView.CorridorLenght)); ;
        _nextView.Init(_player.speedBall.Value);
        //GenerateCoinsAndBombs();
    }



    public CorridorView LoadCorridorView(Transform placeForGame, Vector3 pos)
    {
        var objView = Object.Instantiate(Resources.Load<GameObject>(_config.pathCorridorPrefab), pos, Quaternion.identity,placeForGame);
        AddGameObjects(objView);

        return objView.GetComponent<CorridorView>();
    }

    private void GenerateCoinsAndBombs(Transform corridor)
    {
        var minValForX = corridor.localScale.x / 2 * (-1);
        var maxValForX = corridor.localScale.x / 2;
        var distanceBetweenObj = 10 / 5;//10 - длина коридора, 5 - объектов на одном куске коридора
        Random rnd = new Random();
        for(int i = 0; i < 5; i++)
        {

        }
    }

    public CoinView LoadCoinView(Transform placeForGame, Vector3 pos)
    {
        var objView = Object.Instantiate(Resources.Load<GameObject>(_config.pathCoinPrefab), pos, Quaternion.identity, placeForGame);
        AddGameObjects(objView);
        

        return objView.GetComponent<CoinView>();
    }

    public BombView LoadBombView(Transform placeForGame, Vector3 pos)
    {
        var objView = Object.Instantiate(Resources.Load<GameObject>(_config.pathBombPrefab), pos, Quaternion.identity, placeForGame);
        AddGameObjects(objView);

        return objView.GetComponent<BombView>();
    }
}