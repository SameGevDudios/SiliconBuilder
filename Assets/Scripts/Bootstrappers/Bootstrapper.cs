using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private BuildingList _buildingList;
    [SerializeField] private SpawnBuildingList _spawnList;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private PlayerActions _playerActions;
    [SerializeField] private GameObject _buildablesPanel, _buildableButton;
    [SerializeField] private Button _placeButton, _removeButton;
    private ISelector _selector;
    private IPlacer _placer;

    private void Awake()
    {
        // Placing
        IInput input = new DesktopInput(_playerInput);
        IPlaceValidator validator = new RangeValidator();
        _selector = new Selector(_buildingList);
        PoolManager poolManager = new PoolManager(_buildingList);
        _placer = new Placer(_selector, poolManager);
        IBuildablesListing listing = new BuildablesListing();
        IBuildablesDataHandler dataHandler = new JSONDataHandler(listing, _spawnList);
        IActor placeController = 
            new PlaceController(input, validator, _selector, _placer, listing, dataHandler, _gameSettings.GridSize);

        // Removing
        IRemover remover = new Remover(_gameSettings.RemoveMask, listing, dataHandler);
        IActor removeController = new RemoveController(input, remover);

        // Player Actions
        _playerActions.Constructor(placeController, removeController, _placer);

        // Buttons
        SetupBuildableButtons();
        SetupPlayerActionsButtons();

        // Object pooling
        poolManager.InitPools();

        // Data
        dataHandler.LoadData();

        // Place buildables from saved data
        IAutoPlacer autoPlacer = new AutoPlacer(_placer, listing);
        autoPlacer.Place();

        // Setup components for player interactions
        _selector.SetCurrentBuildable(0);
        _placer.InstantiateCurrentBuildable();
        _playerActions.SwitchToPlace();
    }
    private void SetupBuildableButtons()
    {
        if(_gameSettings.BuildablesAvalable > _buildingList.Buildings.Count)
        {
            Debug.LogError("Cannot instantiate buttons. Value of avalable buildings in config is greater than actual building count.");
            return;
        }
        for (int i = 0; i < _gameSettings.BuildablesAvalable; i++)
        {
            Button button = Instantiate(_buildableButton, _buildablesPanel.transform).GetComponent<Button>();
            int index = i;
            button.onClick.AddListener(() => _selector.SetCurrentBuildable(index));
            button.onClick.AddListener(() => _placer.DisposeCurrentBuildable());
            button.onClick.AddListener(() => _placer.InstantiateCurrentBuildable());
            Transform child = button.transform.GetChild(0);
            child.GetComponent<Image>().sprite = _buildingList.Buildings[i].BuildingSprite;
        }
    }
    private void SetupPlayerActionsButtons()
    {
        _placeButton.onClick.AddListener(() => _playerActions.SwitchToPlace());
        _removeButton.onClick.AddListener(() => _playerActions.SwitchToRemove());
    }
}
