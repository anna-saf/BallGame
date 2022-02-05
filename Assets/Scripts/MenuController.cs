using UnityEngine;

internal class MenuController:BaseController
{
    private Player _player;
    private Transform _placeForUI;
    private MenuView _menuView;
    private Config _config;

    public MenuController(Transform placeForUI, Player player, Config config)
    {
        _player = player;
        _placeForUI = placeForUI;
        _config = config;
        _menuView = LoadView(_placeForUI);

        _menuView.Init(StartButtonClick);
    }

    private MenuView LoadView(Transform placeForUi)
    {
        var objectView = Object.Instantiate(Resources.Load<GameObject>(_config.pathMenuPrefab), placeForUi, false);
        AddGameObjects(objectView);

        return objectView.GetComponent<MenuView>();
    }

    public void StartButtonClick()
    {
        _player.gameState.Value = GameState.Game;
    }
}