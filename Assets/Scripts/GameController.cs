using UnityEngine;

internal class GameController:BaseController
{
    private Player _player;
    private Transform _placeForUI;
    private Transform _placeForGame;
    private MainCamView _mainCam;
    private Config _config;

    private CorridorController _corridorController;
    private BallController _ballController;
    private LivesController _livesController;
    private CoinsCountController _coinsCountController;
    private InputController _inputController;
    //private MainCamController _mainCamController;

    

    public GameController(Transform placeForUI, Player player, Config config, Transform placeForGame, MainCamView mainCam)
    {

        _player = player;
        _placeForUI = placeForUI;
        _placeForGame = placeForGame;
        _config = config;
        _mainCam = mainCam;
        CreateControllersForGameState();
    }

    public void CreateControllersForGameState()
    {
        _corridorController = new CorridorController(_player, _placeForGame, _config);
        AddController(_corridorController);
        _ballController = new BallController(_player, _placeForGame, _config, _mainCam);
        AddController(_ballController);
       /* _mainCamController = new MainCamController(_player);
        AddController(_mainCamController);*/
        _livesController = new LivesController(_config, _placeForUI);
        AddController(_livesController);
        _coinsCountController = new CoinsCountController(_config, _placeForUI);
        AddController(_coinsCountController);
    }
}