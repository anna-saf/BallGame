using UnityEngine;

class LivesController:BaseController
{
    private LivesView _livesView;
    private Config _config;
    private Transform _placeForUI;

    public LivesController(Config config, Transform placeForUI)
    {
        _placeForUI = placeForUI;
        _config = config;
        _livesView = LoadView();
        _livesView.Init(_config);
    }

    public LivesView LoadView()
    {
        var objView = Object.Instantiate(Resources.Load<GameObject>(_config.pathLivesWinPrefab), _placeForUI);
        AddGameObjects(objView);
        return objView.GetComponent<LivesView>();
    }
}