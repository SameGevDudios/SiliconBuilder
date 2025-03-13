using UnityEngine;

[CreateAssetMenu(fileName = "NewGameSettings", menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public int GridSize, BuildablesAvalable;
    public LayerMask RemoveMask;
}
