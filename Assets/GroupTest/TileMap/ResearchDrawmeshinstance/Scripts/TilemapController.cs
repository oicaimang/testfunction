using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    [Header("Load/Save Tilemaps")]
    [SerializeField] Tilemap saveTilemaps;
    [SerializeField] WorldMapData worldMapData;
    [SerializeField] List<TileBase> loadTileBases = new();
    [SerializeField] Dictionary<string, TileBase> _cacheTiles = new();
    AsyncOperationHandle<TileBase> opHandle;
    private void Start()
    {
        saveTilemaps.ClearAllTiles();
        StartCoroutine(Load(worldMapData));
    }
    [ContextMenu("Save Data")]
    public void SaveData()
    {
        Save(worldMapData);
    }
    private void Save(WorldMapData worldMapData)
    {
        saveTilemaps.CompressBounds();
        foreach (var tilePos in saveTilemaps.cellBounds.allPositionsWithin)
        {
            if (saveTilemaps.HasTile(tilePos))
            {
                TileBase tile = saveTilemaps.GetTile(tilePos);
                var listSaveTileData = new List<SaveTileData>();
                if (!worldMapData.GetListName().Contains(tile.name))
                {
                    worldMapData.ListSaveTileDataNames.Add(new SaveTileDataName() { Name = tile.name, TilemapDatas = listSaveTileData });
                }
                var saveTileData = new SaveTileData()
                {
                    pos = new(tilePos.x, tilePos.y),
                    t_matrix = saveTilemaps.GetTransformMatrix(tilePos)
                };
                worldMapData.GetSaveTileDataName(tile.name).TilemapDatas.Add(saveTileData);
            };
        }

    }
    public IEnumerator Load(WorldMapData worldMapData)
    {
        Addressables.InitializeAsync();

        foreach (var tileName in worldMapData.GetListName())
        {
            if (!_cacheTiles.ContainsKey(tileName) && CheckKeyExist(tileName))
            {
                _cacheTiles.Add(tileName, null);
                AsyncOperationHandle<TileBase> handle = Addressables.LoadAssetAsync<TileBase>(tileName);
                yield return handle;
                loadTileBases.Add(handle.Result);
            }
        }
        Debug.Log("here");
        foreach (var tile in loadTileBases) _cacheTiles[tile.name] = tile;

        foreach (var tileName in worldMapData.GetListName())
        {
            saveTilemaps.ClearAllTiles();
            foreach (var savedTileDatas in worldMapData.ListSaveTileDataNames)
            {
                if (_cacheTiles.TryGetValue(savedTileDatas.Name, out var tileBase))
                {
                    foreach (var tileData in worldMapData.GetSaveTileDataName(savedTileDatas.Name).TilemapDatas)
                    {
                        saveTilemaps.SetTile(new TileChangeData()
                        {
                            position = new(tileData.pos.x, tileData.pos.y),
                            tile = tileBase,
                            transform = tileData.t_matrix != Matrix4x4.zero ? tileData.t_matrix : Matrix4x4.identity,
                            color = Color.white
                        }, false);
                    }
                }
            }
            saveTilemaps.RefreshAllTiles();
            saveTilemaps.CompressBounds();

        }
    }
    bool CheckKeyExist(string key)
    {
        foreach (var locator in Addressables.ResourceLocators)
        {
            if (locator.Keys.Contains(key)) return true;
        }
        return false;
    }

}
[Serializable]
public class SaveTileData
{
    public Vector2Int pos;
    public Matrix4x4 t_matrix;
}
[Serializable]
public class WorldMapData
{
    public List<SaveTileDataName> ListSaveTileDataNames;
    private List<string> listName = new();
    public List<string> GetListName()
    {
        listName.Clear();
        foreach (var x in ListSaveTileDataNames)
        {
            listName.Add(x.Name);
        }
        return listName;
    }
    public SaveTileDataName GetSaveTileDataName(string name)
    {
        foreach (var x in ListSaveTileDataNames)
        {
            if (x.Name == name) return x;
        }
        Debug.Log("null");
        return null;
    }

}
[Serializable]
public class SaveTileDataName
{
    public string Name;
    public List<SaveTileData> TilemapDatas;
}
