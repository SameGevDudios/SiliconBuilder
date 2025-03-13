using System.Collections.Generic;

public class BuildablesListing : IBuildablesListing
{
    private List<Buildable> _list = new();

    public void SetList(List<Buildable> list) =>
        _list.AddRange(list);
    public void AddBuildable(string name, float x, float y)
    {
        Buildable buildable = new Buildable { Name = name, X = x, Y = y };
        _list.Add(buildable);
    }
    public void RemoveBuildable(string name, float x, float y)
    {
        Buildable buildable = new Buildable { Name = name, X = x, Y = y };
        _list.Remove(buildable);
    }
    public List<Buildable> GetCurrentBuildables() =>
        _list;
}
