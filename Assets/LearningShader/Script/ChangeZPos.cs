using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeZPos : MonoBehaviour
{
    // public Tilemap tilemap;
    public GameObject posRayOrigin;
    public LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
        // Vector3Int tilemapPos = tilemap.WorldToCell(transform.position);
        // selector = tilemap.GetCellCenterWorld(tilemapPos);
        // Debug.Log(selector.y + "_" + transform.position.y);
        // if (selector.y >= transform.position.y)
        // {
        //     transform.localPosition = new Vector3(transform.position.x, transform.position.y, -1);
        // }
        // else
        // {
        //     transform.localPosition = new Vector3(transform.position.x, transform.position.y, 1);
        // }

        RaycastHit2D hit;
        // Does the ray intersect any objects excluding the player layer
        hit = Physics2D.Raycast(posRayOrigin.transform.position, new Vector3(0, 0, -1), 1000, layerMask);
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, new Vector3(0, 0, -1) * 1000, Color.yellow);
            Debug.Log(hit.collider.name);
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else
        {
            Debug.DrawRay(transform.position, new Vector3(0, 0, -1) * 1000, Color.white);
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, -1);
            Debug.Log("Did not Hit");
        }
    }

}
