public class RemoveController : IRemoveController
{
    private IInput _input;
    private IRemover _remover;

    public void Update()
    {
        if (_input.CursorDown())
            _remover.Remove(_input.CursorWorldPosition());
    }
}
