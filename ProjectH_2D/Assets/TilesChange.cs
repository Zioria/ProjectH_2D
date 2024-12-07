using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChanger : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public float maxDistance = 5f;  // Maximum range for tile changes
    public Transform player;  // Reference to the player
    public float movementSpeed = 3f;  // Player movement speed
    private Vector3 targetPosition;  // Target position for the player
    private bool isMoving = false;  // Is the player currently moving?

    [Header("Key_Item")]
    public Item KeyItem_Hoe;  // Reference to the hoe item
    public Item KeyItem_Watering;  // Reference to the watering can item
    [Space]

    public Tilemap tilemap;  // Reference to the tilemap to modify
    public TileLibrary tileLibrary;  // Tile library to store different tiles

    public RuleTile type1RuleTile;  // Reference to the Rule Tile for Type 1 (e.g., un-tiled ground)
    private TileBase type2Tile;  // Type 2 tile (e.g., tilled soil)
    private TileBase type3Tile;  // Type 3 tile (e.g., watered soil)

    private Camera mainCamera;  // Reference to the camera
    private Vector3Int targetCell;  // Target cell for the tile change

    void Start()
    {
        CheckTileLibrary();

        type2Tile = tileLibrary.tiles[0];  // Type 2 - Tilled Soil
        type3Tile = tileLibrary.tiles[1];  // Type 3 - Watered Soil

        mainCamera = Camera.main;  // Get the main camera
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left click
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Tilemap"))
            {
                Vector3 worldPosition = hit.point;
                targetCell = tilemap.WorldToCell(worldPosition);
                targetPosition = tilemap.GetCellCenterWorld(targetCell);  // Center of the clicked tile

                // Get the selected item
                Item receivedItem = inventoryManager.GetSelcetedItem();
                TileBase currentTile = tilemap.GetTile(targetCell);

                // Check if the tool matches the action
                if ((receivedItem == KeyItem_Hoe && currentTile == type1RuleTile) ||
                    (receivedItem == KeyItem_Watering && currentTile == type2Tile))
                {
                    isMoving = true;  // Start moving the player
                }
                else
                {
                    Debug.Log("Invalid tool selected. Player will not move.");
                }
            }
        }

        if (isMoving)
        {
                MovePlayer();
        }
    }

    private void MovePlayer()
    {
        float step = movementSpeed * Time.deltaTime;
        player.position = Vector3.MoveTowards(player.position, targetPosition, step);


        if (Vector3.Distance(player.position, targetPosition) < 0.1f)
        {
            isMoving = false;  // Stop moving
            ChangeTile();
        }
    }

    private void ChangeTile()
    {
        TileBase currentTile = tilemap.GetTile(targetCell);
        Item receivedItem = inventoryManager.GetSelcetedItem();

        if (receivedItem == KeyItem_Hoe && currentTile == type1RuleTile)
        {
            tilemap.SetTile(targetCell, type2Tile);
            Debug.Log("Soil tilled.");
        }
        else if (receivedItem == KeyItem_Watering && currentTile == type2Tile)
        {
            tilemap.SetTile(targetCell, type3Tile);
            Debug.Log("Soil watered.");
        }
    }

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
