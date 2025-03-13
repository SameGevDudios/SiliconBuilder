using UnityEngine;

public class AutoPlacer : IAutoPlacer
{
    private IPlacer _placer;
    private IBuildablesListing _listing;

    public AutoPlacer(IPlacer placer, IBuildablesListing listing)
    {
        _placer = placer;
        _listing = listing;
    }
    public void Place()
    {
        foreach(Buildable buildable in _listing.GetCurrentBuildables())
            _placer.InstantiateBuildable(buildable.Name, new Vector3(buildable.X, buildable.Y, 0));
    }
}
