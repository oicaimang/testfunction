using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeZPos : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3 selector;
    // Update is called once per frame
    void Update()
    {
        Vector3Int tilemapPos = tilemap.WorldToCell(transform.position);
        selector = tilemap.GetCellCenterWorld(tilemapPos);
        Debug.Log(selector.y + "_" + transform.position.y);
        if (selector.y >= transform.position.y)
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, -1);
        }
        else
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, 1);
        }
    }
}
