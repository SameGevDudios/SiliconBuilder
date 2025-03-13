using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "Buildings/Building")]
public class Building : ScriptableObject
{
    public Sprite BuildingSprite;
    public string PoolingName;
    public int Size;
    public float GridOffset =>
        Size % 2 == 0 ? 0 : 0.5f;
}
