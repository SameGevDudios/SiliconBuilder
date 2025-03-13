using UnityEngine;
using UnityEngine.Windows;

public class Remover : IRemover
{
    private LayerMask _removeMask;
    private IBuildablesListing _listing;
    private IBuildablesDataHandler _dataHandler;

    public Remover(LayerMask removeMask) 
    {
        _removeMask = removeMask; 
    }
    public void Remove(Vector3 position)
    {
        GameObject buildable = FindBuildable(position);
        if (buildable != null)
        {
            buildable.SetActive(false);
            int cut = 7; // for removing "(Clone)" in gameobject's name
            string name = cut <= buildable.name.Length ? buildable.name.Substring(0, buildable.name.Length - cut) : "";
            Vector3 buildablePosition = buildable.transform.position;
            _listing.RemoveBuildable(
                name,
                float.Parse(buildablePosition.x.ToString("0.0")),
                float.Parse(buildablePosition.y.ToString("0.0"))
                );
            _dataHandler.SaveData();
        }
    }
    private GameObject FindBuildable(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector3.forward, int.MaxValue, _removeMask);
        return hit ? hit.collider.gameObject : null;
    }
}
