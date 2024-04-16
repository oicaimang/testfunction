using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContainerData : MonoBehaviour
{
    public PlayerBaseData playerDataPrefab;
    public List<PlayerBaseData> Datas;
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            var playerData = Instantiate(playerDataPrefab, transform);
            Datas.Add(playerData);
        }
    }
}
