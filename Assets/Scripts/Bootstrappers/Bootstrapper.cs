using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private BuildingList _buildingList;
    [SerializeField] private PoolManager _poolManager;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private PlayerActions _playerActions;
    [SerializeField] private Button[] _buildableButtons;
    private void Awake()
    {
        // Placing
        IInput input = new DesktopInput(_playerInput);
        IPlaceValidator validator = new RangeValidator();
        ISelector selector = new Selector(_buildingList);
        IPlacer placer = new Placer(selector, _poolManager);
        IPlaceController placeController = new PlaceController(input, validator, selector, placer, _gameSettings.GridSize);

        // Removing
        IRemover remover = new Remover(_gameSettings.RemoveMask);
        IRemoveController removeController = new RemoveController(input, remover);

        // Player Actions
        _playerActions.Constructor(placeController, removeController, placer);

        // Buttons
        SetupBuildableButtons(selector);
    }
    private void SetupBuildableButtons(ISelector selector)
    {
        for (int i = 0; i < _buildableButtons.Length; i++)
            _buildableButtons[i].onClick.AddListener(() => selector.SetCurrentBuildable(i));
    }
}
