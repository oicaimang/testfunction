using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUInstancerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int instances = 100;
    private List<GPUInstancerObject> gPUInstancerObjectCache = new List<GPUInstancerObject>();
    [SerializeField] private GPUInstancerObject gPUInstancerObjectPrefab;
    public Vector3 maxPos;
    private Mesh objMesh;
    private Material objMat;

    void Start()
    {
        for (int i = 0; i < instances; i++)
        {
            Vector3 position = new Vector3(Random.Range(-maxPos.x, maxPos.x), Random.Range(-maxPos.y, maxPos.y), Random.Range(-maxPos.z, maxPos.z));
            var spawnPrefab = Instantiate(gPUInstancerObjectPrefab, position, Quaternion.identity);
            gPUInstancerObjectCache.Add(spawnPrefab);
            objMesh = spawnPrefab.GetComponent<MeshFilter>().mesh;
            objMat = spawnPrefab.GetComponent<MeshRenderer>().material;
            spawnPrefab.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void LateUpdate()
    {
        // UpdateBuffers(cameraData);
        List<Matrix4x4> matrix = new();
        for (int i = 0; i < instances; i++)
        {
            if (gPUInstancerObjectCache[i] != null)
            {
                matrix.Add(gPUInstancerObjectCache[i].GetInstanceTransform(true).localToWorldMatrix);
                // if call here => per i will draw 1 batch
                // Graphics.DrawMeshInstanced(objMesh, 0, objMat, matrix);
            }
        }
        Debug.Log(matrix.Count);
        Graphics.DrawMeshInstanced(objMesh, 0, objMat, matrix.ToArray());
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, 2 * maxPos);
    }
}
