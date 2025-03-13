using UnityEngine;

public interface IInput
{
    Vector2 Movement();
    Vector3 CursorWorldPosition();
    bool CursorDown();
    bool CursorOverUI();
}
