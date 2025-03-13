using UnityEngine;

public class RangeValidator : IPlaceValidator
{
    public bool CanPlace(Vector3 placePosition, float range) =>
        Physics.OverlapSphere(placePosition, range).Length < 2;
}
