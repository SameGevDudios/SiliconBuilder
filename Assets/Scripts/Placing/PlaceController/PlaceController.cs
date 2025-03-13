using UnityEngine;

public class PlaceController : IPlaceController
{
    private IInput _input;
    private IPlaceValidator _validator;
    private ISelector _selector;
    private IPlacer _placer;
    private int _gridSize;

    public PlaceController(IInput input, IPlaceValidator validator, ISelector selector, IPlacer placer, int gridSize)
    {
        _input = input;
        _validator = validator;
        _selector = selector;
        _placer = placer;
        _gridSize = gridSize;
    }
    public void Update()
    {
        Vector3 gridPosition = GridPosition();
        if (_validator.CanPlace(gridPosition, _selector.GetCurrentBuildable().Size / 2))
        {
            if (!_input.CursorOverUI())
            {
                _placer.UpdatePosition(gridPosition);
                if (_input.CursorDown())
                {
                    _placer.InstantiateCurrentBuildable();
                }
            }
        }
    }
    public Vector3 GridPosition()
    {
        Vector3 cursorPosition = _input.CursorWorldPosition();
        Vector3 gridPosition = new Vector3(
            (int)(cursorPosition.x / _gridSize),
            (int)(cursorPosition.y / _gridSize),
            (int)(cursorPosition.z / _gridSize));
        return gridPosition;
    }
}
