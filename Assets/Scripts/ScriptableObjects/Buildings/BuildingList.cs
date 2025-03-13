using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuildingsList", menuName = "Buildings/Buildings List")]
public class BuildingList : ScriptableObject
{
    public List<Building> Buildings = new();
}
