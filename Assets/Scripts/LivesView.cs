using System.Collections.Generic;
using UnityEngine;

public class LivesView:MonoBehaviour
{
    [SerializeField] private int _livesCount;
    private List<Live> _lives;
    private Config _config;

    public void Init(Config config)
    {
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

    public void LastOneLife()
    {
        _lives[0].OnDestroy();
        _lives.RemoveAt(0);
    }

}