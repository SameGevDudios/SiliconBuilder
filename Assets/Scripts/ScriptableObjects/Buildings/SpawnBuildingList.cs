using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnList", menuName = "Buildings/Spawn Buildings List")]
public class SpawnBuildingList : ScriptableObject
{
    public List<Buildable> Buildings = new();
}
