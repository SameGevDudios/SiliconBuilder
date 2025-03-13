using UnityEngine;

public class Placer : IPlacer
{
    private PoolManager _poolManager;
    private GameObject _currentBuildable;

    public Placer(PoolManager poolManager)
    {
        _poolManager = poolManager;
    }
    public void InstantiateBuildable(string name) =>
        _currentBuildable = _poolManager.InstantiateFromPool(name, Vector3.zero, Quaternion.identity);
    public void InstantiateBuildable(string name, Vector3 position) =>
        _currentBuildable = _poolManager.InstantiateFromPool(name, position, Quaternion.identity);
    public void UpdatePosition(Vector3 newPosition) =>
        _currentBuildable.transform.position = newPosition;
}
