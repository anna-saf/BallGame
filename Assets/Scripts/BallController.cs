using UnityEngine;

internal class BallController:BaseController
{
    private Player _player;
    private Transform _placeForGame;
    private Config _config;
    private BallView _ballView;
    private MainCamView _mainCamView;

    

    public BallController(Player player, Transform placeForGame, Config config, MainCamView mainCam)
    {

        _config = config;
        _placeForGame = placeForGame;
        _player = player;
        _mainCamView = mainCam;
        _ballView = LoadView();
        //_ballView.Init(_mainCamView, _player.speedBall.Value);
        //_mainCamView.GetOffset(_ballView.transform);
        //_ballView.StartCoroutineMove(_player.speedBall.Value);
        //player.speedBall.SubscribeOnChange(_ballView.SpeedChange);
    }

    public BallView LoadView()
    {
        var objView = Object.Instantiate(Resources.Load<GameObject>(_config.pathBallPrefab), _placeForGame, false);
        AddGameObjects(objView);

        return objView.GetComponent<BallView>();
    }

    
    
}