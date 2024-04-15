using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelEditor : MonoBehaviour
{
    [SerializeField] Tilemap currentTileMap;
    [SerializeField] TileBase currentTile;
    [SerializeField] Camera cam;
    private void Update()
    {
        Vector3Int pos = currentTileMap.WorldToCell(cam.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButton(0))
        {
            PlaceTile(pos);
        }
    }
    void PlaceTile(Vector3Int pos)
    {
        var newPos = new Vector3Int(pos.x, pos.y, (int)cam.transform.position.z + 1);
        currentTileMap.SetTile(newPos, currentTile);
    }
}
