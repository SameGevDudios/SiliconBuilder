using System.Collections.Generic;

public interface IBuildablesListing
{
    void SetList(List<Buildable> list);
    void AddBuildable(string name, float x, float y);
    void RemoveBuildable(string name, float x, float y);
    List<Buildable> GetCurrentBuildables();
}
