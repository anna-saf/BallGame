using System.Collections.Generic;
using UnityEngine;

public class LivesView:MonoBehaviour
{
    [SerializeField] private int _livesCount;
    private List<Live> _lives;
    private Config _config;
    private Player _player;

    public void Init(Config config, Player player)
    {
        _player = player;
        _player.lives.SubscribeOnChange(LeaveOneLive);
        _config = config;
        _lives = new List<Live>();
        for (int i = 0; i < _livesCount; i++)
        {
            _lives.Add(LoadView());
        }
    }

    public Live LoadView()
    {
        var objView = Object.Instantiate(Resources.Load<GameObject>(_config.pathLivePrefab), transform);
        return objView.GetComponent<Live>();
    }

    public void LastOneLive()
    {
        _lives[0].OnDestroy();
        _lives.RemoveAt(0);
    }

    public void LeaveOneLive(int lives)
    {
        var livesCountNow = _livesCount - lives;
        if (livesCountNow == 0)
        {
            LastOneLive();
        }
        else if (livesCountNow < 0) { }
        else
        {
            _lives[livesCountNow].OnDestroy();
            _lives.RemoveAt(livesCountNow);
        }
    }

}