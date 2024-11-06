using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesChange : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public float maxDistance = 0f;
    public Transform Player;
    public Vector3Int targetCellPosition;


    [Header("Key_Item")]
    public Item KeyItem_Hoe;
    public Item KeyItem_Watering;
    [Space]

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
        Vector3 playerPos = Player.position;                  // Get the player's position in world coordinates
        Vector3Int playerCell = tilemap.WorldToCell(playerPos);        // Convert player position to a grid cell

        // Loop over a small area around the player to find nearby tiles
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector3Int cellPosition = playerCell + new Vector3Int(x, y, 0); // Get each cell around the player

                // Convert cell position to world position
                Vector3 cellWorldPos = tilemap.CellToWorld(cellPosition);

                // Calculate the distance between the player and the cell
                float distance = Vector3.Distance(playerPos, cellWorldPos);

                // Check if the distance is within maxDistance
                if (distance <= maxDistance)
                {
                    Debug.Log("Tile within range at position " + cellPosition + " with distance: " + distance);
                }
            }
        }


        if (Input.GetMouseButtonDown(0))  // Detect left mouse button click
        {
            Item receivedItem = inventoryManager.GetSelcetedItem();
            

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // Get world position of mouse click
            Vector3Int clickedCell = tilemap.WorldToCell(mouseWorldPos);  // Convert to grid cell position

            TileBase currentTile = tilemap.GetTile(clickedCell);  // Get the current tile at the clicked position

            // Check distance from player to clicked tile
            

            if (receivedItem != null)
            {
                Debug.Log("Received item: " + receivedItem);
            }
            else
            {
                Debug.Log("No Item received!");
            }

            // Check if the current tile is the Rule Tile for Type 1
            if (currentTile == type1RuleTile && receivedItem == KeyItem_Hoe )
            {
                // Change Type 1 (Rule Tile) to Type 2
                tilemap.SetTile(clickedCell, type2Tile);
            }
            else if (currentTile == type2Tile && receivedItem == KeyItem_Watering)
            {
                // Change Type 2 to Type 3
                tilemap.SetTile(clickedCell, type3Tile);
            }
            else if (currentTile == type3Tile)
            {
                // Change Type 3 back to Type 1 (Rule Tile)
                //tilemap.SetTile(clickedCell, type1RuleTile);
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
