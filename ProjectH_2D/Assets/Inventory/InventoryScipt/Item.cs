using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    public ItemType Type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Bolt")]
    public Sprite image;

}

public enum ItemType
{
    Tool
}

public enum ActionType
{
    Dig,
    Mine,
    Water_Tool
}
