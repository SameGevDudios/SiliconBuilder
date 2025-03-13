using UnityEngine;

public interface IInput
{
    Vector3 CursorWorldPosition();
    bool CursorDown();
    bool CursorOverUI();
}
