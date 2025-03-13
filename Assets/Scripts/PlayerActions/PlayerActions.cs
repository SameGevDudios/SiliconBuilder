using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private IPlaceController _placeController;
    private IRemoveController _removeController;
    private IPlacer _placer;
    private bool _isPlacing;

    public void Constructor(IPlaceController placeController, IRemoveController removeController, IPlacer placer)
    {
        _placeController = placeController;
        _removeController = removeController;
        _placer = placer;
        _isPlacing = true;
    }
    private void Update()
    {
        if(_isPlacing)
            _placeController.Update();
        else
            _removeController.Update();
    }
    public void SwitchToPlace() =>
        _isPlacing = true;
    public void SwitchToRemove()
    {
        _placer.DisposeCurrentBuildable();
        _isPlacing = false;
    }
}
