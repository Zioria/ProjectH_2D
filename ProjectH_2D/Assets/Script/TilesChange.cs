using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesChange : MonoBehaviour
{
    public Tilemap tilemap;            // Reference to the tilemap
    public TileLibrary tileLibrary;    // Reference to the TileLibrary

    public RuleTile type1RuleTile;     // Reference to the Rule Tile for Type 1

    private TileBase type2Tile;        // Reference to Type 2 tile
    private TileBase type3Tile;        // Reference to Type 3 tile

    void Start()
    {
        // Ensure that the Tile Library is correctly set up
        CheckTileLibrary();

        // Assume the first two tiles in the TileLibrary are Type 2 and Type 3
        type2Tile = tileLibrary.tiles[0];  // Type 2
        type3Tile = tileLibrary.tiles[1];  // Type 3
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Detect left mouse button click
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // Get world position of mouse click
            Vector3Int clickedCell = tilemap.WorldToCell(mouseWorldPos);  // Convert to grid cell position

            TileBase currentTile = tilemap.GetTile(clickedCell);  // Get the current tile at the clicked position

            // Check if the current tile is the Rule Tile for Type 1
            if (currentTile == type1RuleTile)
            {
                // Change Type 1 (Rule Tile) to Type 2
                tilemap.SetTile(clickedCell, type2Tile);
            }
            else if (currentTile == type2Tile)
            {
                // Change Type 2 to Type 3
                tilemap.SetTile(clickedCell, type3Tile);
            }
            else if (currentTile == type3Tile)
            {
                // Change Type 3 back to Type 1 (Rule Tile)
                tilemap.SetTile(clickedCell, type1RuleTile);
            }
        }
    }

    // Method to check if the Tile Library is correctly set up
    void CheckTileLibrary()
    {
        if (tileLibrary == null)
        {
            Debug.LogError("Tile Library is not assigned!");
            return;
        }

        if (tileLibrary.tiles == null || tileLibrary.tiles.Length < 2)
        {
            Debug.LogError("Tile Library must contain at least Type 2 and Type 3 tiles!");
        }
        else
        {
            Debug.Log("Tile Library is properly set up with " + tileLibrary.tiles.Length + " tiles.");
        }
    }
}
