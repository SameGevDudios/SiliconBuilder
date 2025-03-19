using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private IActor _placeController, _removeController, _currentActor;
    private IPlacer _placer;

    public void Constructor(IActor placeController, IActor removeController, IPlacer placer)
    {
        _placeController = placeController;
        _removeController = removeController;
        _placer = placer;
    }
    private void Update()
    {
        _currentActor.Update();
    }
    public void SwitchToPlace() =>
        _currentActor = _placeController;
    public void SwitchToRemove()
    {
        _placer.DisposeCurrentBuildable();
        _currentActor = _removeController;
    }
}
