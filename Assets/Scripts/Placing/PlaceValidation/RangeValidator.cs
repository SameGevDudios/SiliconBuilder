using UnityEngine;

public class RangeValidator : IPlaceValidator
{
    public bool CanPlace(Vector3 placePosition, float range) =>
        Physics2D.OverlapCircleAll(placePosition, range).Length < 2;
}
