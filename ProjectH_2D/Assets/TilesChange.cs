using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChanger : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public float maxDistance = 5f;  // Maximum range for tile changes
    public Transform player;
     private Vector3Int playerCellPosition;

    [Header("Key_Item")]
    public Item KeyItem_Hoe;  // Reference to the hoe item
    public Item KeyItem_Watering;  // Reference to the watering can item
    [Space]

    public Tilemap tilemap;  // Reference to the tilemap to modify
    public TileLibrary tileLibrary;  // Tile library to store different tiles

    public RuleTile type1RuleTile;  // Reference to the Rule Tile for Type 1 (e.g., un-tiled ground)
    private TileBase type2Tile;  // Type 2 tile (e.g., tilled soil)
    private TileBase type3Tile;  // Type 3 tile (e.g., watered soil)

    void Start()
    {
        // Ensure that the Tile Library is correctly set up
        CheckTileLibrary();

        // Assume the first two tiles in the TileLibrary are Type 2 (tilled) and Type 3 (watered)
        type2Tile = tileLibrary.tiles[0];  // Type 2 - Tilled Soil
        type3Tile = tileLibrary.tiles[1];  // Type 3 - Watered Soil
    }

    void Update()
    {
        // Convert the player's world position to tilemap cell position
        Vector3 playerPos = player.position;
        playerCellPosition = tilemap.WorldToCell(playerPos);

        if (Input.GetMouseButtonDown(0))  // Left click to use tools
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickedCell = tilemap.WorldToCell(mouseWorldPos);

            // Get the selected item from the inventory
            Item receivedItem = inventoryManager.GetSelcetedItem();

            // Check if the clicked tile is in range (maxDistance)
            float distance = Vector3.Distance(player.position, tilemap.CellToWorld(clickedCell));
            if (distance <= maxDistance)
            {

                
                HandleToolUsage(clickedCell, receivedItem);

            }
        }

    }

    private void HandleToolUsage(Vector3Int clickedCell, Item receivedItem)
    {
        // Get the current tile at the clicked position
        TileBase currentTile = tilemap.GetTile(clickedCell);

        if (receivedItem == KeyItem_Hoe && currentTile == type1RuleTile)  // If Hoe is used on empty ground
        {
            // Change to tilled soil
            tilemap.SetTile(clickedCell, type2Tile);
            Debug.Log("Soil tilled.");
        }
        else if (receivedItem == KeyItem_Watering && currentTile == type2Tile)  // Water the crops
        {
            // Change tilled soil to watered soil (you could implement a crop system here)
            tilemap.SetTile(clickedCell, type3Tile);
            Debug.Log("Soil watered.");
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
