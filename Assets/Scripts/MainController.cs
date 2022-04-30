using UnityEngine;

internal class MainController:BaseController
{
    private Transform _placeForUI;
    private Transform _placeForGame;
    private MainCamView _mainCam;

    private float _startSpeed;
    private int _startGold;
    private int _startLives;
    private Player _player;

    private MenuController _menuController;
    private GameController _gameController;
    private Config _config;

    public MainController(Transform placeForUI, float startSpeed, int startGold, int startLives, Config config, Transform placeForGame, MainCamView mainCam)
    {
        _config = config;
        _placeForUI = placeForUI;
        _placeForGame = placeForGame;

        _mainCam = mainCam;
        _startSpeed = startSpeed;
        _startGold = startGold;
        _startLives = startLives; 
        _player = new Player(_startSpeed, _startGold, _startLives);
        _player.gameState.Value = GameState.Menu;
        
        ChangeGameState(_player.gameState.Value);
        _player.gameState.SubscribeOnChange(ChangeGameState);
    }

    public override void OnDispose()
    {
        _player.gameState.UnSubscriptionOnChange(ChangeGameState);
        _menuController?.Dispose();
        _gameController?.Dispose();
        base.OnDispose();
    }

    private void ChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Menu:
                _gameController?.Dispose();
                _menuController = new MenuController(_placeForUI, _player, _config);
                break;
            case GameState.Game:
                _menuController?.Dispose();
                _gameController = new GameController(_placeForUI, _player, _config, _placeForGame, _mainCam);                
                break;
            case GameState.GameOver:
                _gameController?.Dispose();
                _player = new Player(_startSpeed, _startGold, _startLives);
                _player.gameState.Value = GameState.Menu;
                ChangeGameState(_player.gameState.Value);
                _player.gameState.SubscribeOnChange(ChangeGameState);
                break;
            default:
                _menuController?.Dispose();
                _gameController?.Dispose();
                break;

        }
    }
}