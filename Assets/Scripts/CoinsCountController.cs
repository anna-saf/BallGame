using UnityEngine;

public class CoinsCountController:BaseController
{
    private CoinsCountView _coinsCountView;
    private Config _config;
    private Transform _placeForUI;
    private Player _player;

    public CoinsCountController(Config config, Transform placeForUI, Player player)
    {
        _player = player;
        _placeForUI = placeForUI;
        _config = config;
        _coinsCountView = LoadView();
        _coinsCountView.Init(_player);
    }

    public CoinsCountView LoadView()
    {
        var objView = Object.Instantiate(Resources.Load<GameObject>(_config.pathCoinCounterPrefab), _placeForUI);
        AddGameObjects(objView);
        return objView.GetComponent<CoinsCountView>();
    }
}