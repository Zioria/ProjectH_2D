using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileLibrary", menuName = "Tile/TileLibrary")]
public class TileLibrary : ScriptableObject
{
    public Tile[] tiles;  // Array to store different tiles
}
