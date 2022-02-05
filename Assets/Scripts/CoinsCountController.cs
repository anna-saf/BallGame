using UnityEngine;

public class CoinsCountController:BaseController
{
    private CoinsCountView _coinsCountView;
    private Config _config;
    private Transform _placeForUI;

    public CoinsCountController(Config config, Transform placeForUI)
    {
        _placeForUI = placeForUI;
        _config = config;
        _coinsCountView = LoadView();
    }

    public CoinsCountView LoadView()
    {
        var objView = Object.Instantiate(Resources.Load<GameObject>(_config.pathCoinCounterPrefab), _placeForUI);
        AddGameObjects(objView);
        return objView.GetComponent<CoinsCountView>();
    }
}