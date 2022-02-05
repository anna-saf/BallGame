using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class BaseController : IDisposable
{
    private List<BaseController> _baseControllers = new List<BaseController>();
    private List<GameObject> _gameObjects = new List<GameObject>();
    private bool _isDisposed;
    
    public void Dispose()
    {
        if (_isDisposed) 
            return;             
        
        _isDisposed = true;

        

        foreach (var baseController in _baseControllers)
            baseController?.Dispose();
                
        _baseControllers.Clear();
        
        foreach (var cachedGameObject in _gameObjects)
            Object.Destroy(cachedGameObject);
                
        _gameObjects.Clear();

        
    }

    /*public void DisposeOneController(BaseController controller)
    {
        if (_baseControllers.Contains(controller))
        {
            _baseControllers[_baseControllers.IndexOf(controller)]?.Dispose();
            _baseControllers.Remove(controller);
        }
    }*/

    protected void AddController(BaseController baseController)
    {
        _baseControllers.Add(baseController);
    }

    protected void AddGameObjects(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
    }

    public virtual void OnDispose() { }
}
