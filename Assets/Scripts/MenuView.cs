using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

internal class MenuView:MonoBehaviour
{
    [SerializeField] private Button _startButton;

    public void Init(UnityAction action)
    {
        _startButton.onClick.AddListener(action);
    }
}