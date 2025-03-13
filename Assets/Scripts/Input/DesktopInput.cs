using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DesktopInput : IInput
{
    private PlayerInput _playerInput;

    public DesktopInput(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }
    public Vector3 CursorWorldPosition()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 offset = Vector3.down * -10;
        return Camera.main.ScreenToWorldPoint(mousePosition) + offset;
    }
    public bool CursorDown() =>
        _playerInput.actions["CursorDown"].ReadValue<bool>();
    public bool CursorOverUI() =>
        EventSystem.current.IsPointerOverGameObject();
}
