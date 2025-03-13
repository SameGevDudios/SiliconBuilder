using UnityEngine;

public class Placer : IPlacer
{
    private ISelector _selector;
    private PoolManager _poolManager;
    private GameObject _currentBuildable;

    public Placer(ISelector selector, PoolManager poolManager)
    {
        _selector = selector;
        _poolManager = poolManager;
    }
    public void InstantiateCurrentBuildable()
    {
        string name = _selector.GetCurrentBuildable().PoolingName;
        _currentBuildable = _poolManager.InstantiateFromPool(name, Vector3.zero, Quaternion.identity);
    }
    public void DisposeCurrentBuildable()
    {
        _currentBuildable.SetActive(false);
        _currentBuildable = null;
    }
    public void InstantiateBuildable(string name, Vector3 position) =>
        _currentBuildable = _poolManager.InstantiateFromPool(name, position, Quaternion.identity);
    public void UpdatePosition(Vector3 newPosition)
    {
        if(_currentBuildable != null )
        {
            _currentBuildable.transform.position = newPosition;
        }
    }
}
