using UnityEngine;

public interface IPlacer
{
    void InstantiateBuildable(string name);
    void UpdatePosition(Vector3 newPosition);
}
