using UnityEngine;

class LivesController:BaseController
{
    private LivesView _livesView;
    private Config _config;
    private Transform _placeForUI;
    private Player _player;

    public LivesController(Config config, Transform placeForUI, Player player)
    {
        _player = player;
        _placeForUI = placeForUI;
        _config = config;
        _livesView = LoadView();
        _livesView.Init(_config, _player);
    }

    public LivesView LoadView()
    {
        var objView = Object.Instantiate(Resources.Load<GameObject>(_config.pathLivesWinPrefab), _placeForUI);
        AddGameObjects(objView);
        return objView.GetComponent<LivesView>();
    }
}