using UnityEngine;

public class Remover : IRemover
{
    private LayerMask _removeMask;

    public Remover(LayerMask removeMask) 
    {
        _removeMask = removeMask; 
    }
    public void Remove(Vector3 position)
    {
        GameObject buildable = FindBuildable(position);
        if (buildable != null)
            buildable.SetActive(false);
    }
    private GameObject FindBuildable(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector3.forward, int.MaxValue, _removeMask);
        return hit ? hit.collider.gameObject : null;
    }
}
