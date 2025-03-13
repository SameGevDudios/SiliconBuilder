public class Selector : ISelector
{
    private BuildingList _list;
    private Building _currentBuilding;

    public Selector(BuildingList list)
    {
        _list = list;
    }
    public void SetCurrentBuildable(int index) =>
        _currentBuilding = _list.Buildings[index];
    public Building GetCurrentBuildable() =>
        _currentBuilding;
}
