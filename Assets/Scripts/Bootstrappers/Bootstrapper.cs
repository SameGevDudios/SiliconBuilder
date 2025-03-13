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
    [SerializeField] private Button _placeButton, _removeButton;

    ISelector _selector;
    IPlacer _placer;

    private void Awake()
    {
        // Placing
        IInput input = new DesktopInput(_playerInput);
        IPlaceValidator validator = new RangeValidator();
        _selector = new Selector(_buildingList);
        _placer = new Placer(_selector, _poolManager);
        IPlaceController placeController = new PlaceController(input, validator, _selector, _placer, _gameSettings.GridSize);

        // Removing
        IRemover remover = new Remover(_gameSettings.RemoveMask);
        IRemoveController removeController = new RemoveController(input, remover);

        // Player Actions
        _playerActions.Constructor(placeController, removeController, _placer);

        // Buttons
        SetupBuildableButtons();
        SetupPlayerActionsButtons();

    }
    private void Start()
    {
        _selector.SetCurrentBuildable(0);
        _placer.InstantiateCurrentBuildable();
    }
    private void SetupBuildableButtons()
    {
        for (int i = 0; i < _buildableButtons.Length; i++)
        {
            int index = i;
            _buildableButtons[i].onClick.AddListener(() => _selector.SetCurrentBuildable(index));
            _buildableButtons[i].onClick.AddListener(() => _placer.DisposeCurrentBuildable());
            _buildableButtons[i].onClick.AddListener(() => _placer.InstantiateCurrentBuildable());
            Transform child = _buildableButtons[i].transform.GetChild(0);
            child.GetComponent<Image>().sprite = _buildingList.Buildings[i].BuildingSprite;
        }
    }
    private void SetupPlayerActionsButtons()
    {
        _placeButton.onClick.AddListener(() => _playerActions.SwitchToPlace());
        _removeButton.onClick.AddListener(() => _playerActions.SwitchToRemove());
    }
}
