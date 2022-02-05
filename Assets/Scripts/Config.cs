using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{

    private const string _pathMenuPrefab = "Prefabs/Menu";
    private const string _pathBallPrefab = "Prefabs/Ball";
    private const string _pathCoinPrefab = "Prefabs/Coin";
    private const string _pathBombPrefab = "Prefabs/Bomb";
    private const string _pathCoinCounterPrefab = "Prefabs/CoinsCounter";
    private const string _pathCorridorPrefab = "Prefabs/Corridor";
    private const string _pathLivePrefab = "Prefabs/Live";
    private const string _pathLivesWinPrefab = "Prefabs/Lives";

    public string pathMenuPrefab
    {
        get
        {
            return _pathMenuPrefab;
        }
    }

    public string pathBallPrefab
    {
        get
        {
            return _pathBallPrefab;
        }
    }

    public string pathCoinPrefab
    {
        get
        {
            return _pathCoinPrefab;
        }
    }

    public string pathBombPrefab
    {
        get
        {
            return _pathBombPrefab;
        }
    }

    public string pathCoinCounterPrefab
    {
        get
        {
            return _pathCoinCounterPrefab;
        }
    }

    public string pathCorridorPrefab
    {
        get
        {
            return _pathCorridorPrefab;
        }
    }

    public string pathLivePrefab
    {
        get
        {
            return _pathLivePrefab;
        }
    }

    public string pathLivesWinPrefab
    {
        get
        {
            return _pathLivesWinPrefab;
        }
    }
}
