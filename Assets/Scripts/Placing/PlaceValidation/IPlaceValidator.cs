using UnityEngine;

public interface IPlaceValidator
{
    bool CanPlace(Vector3 placePosition, float range);
}
