using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "Buildings/Building")]
public class Building : ScriptableObject
{
    [Header("Visuals")]
    public Sprite BuildingSprite;
    public int Size;
    [Space(1), Header("Pooling")]
    public string PoolingName;
    public GameObject Prefab;
    public int PoolingSize;
    public float GridOffset =>
        Size % 2 == 0 ? 0 : -0.5f;
}
