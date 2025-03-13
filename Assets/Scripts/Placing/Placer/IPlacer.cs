using UnityEngine;

public interface IPlacer
{
    void InstantiateCurrentBuildable();
    void InstantiateBuildable(string name, Vector3 position);
    void UpdatePosition(Vector3 newPosition);
}
