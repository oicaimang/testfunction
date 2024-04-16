using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnerObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject prefabs;
    public Vector3 maxPos;
    void Start()
    {
        for (int i = 0; i < 500; i++)
        {
            Vector3 position = new Vector3(Random.Range(-maxPos.x, maxPos.x), Random.Range(-maxPos.y, maxPos.y), Random.Range(-maxPos.z, maxPos.z));
            GameObject obj = Instantiate(prefabs, position, transform.rotation, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
