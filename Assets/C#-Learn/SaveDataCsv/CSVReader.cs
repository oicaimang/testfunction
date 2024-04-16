using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;
    public PlayerContainerData playerContainerData;
    public void OnClickReadCSV()
    {
        ReadCSV();
    }
    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);
        int tablesize = data.Length / 4 - 1;
        for (int i = 0; i < tablesize; i++)
        {
            playerContainerData.Datas[i].nameObject = data[4 * (i + 1)];
            playerContainerData.Datas[i].damage = int.Parse(data[4 * (i + 1) + 1]);
            playerContainerData.Datas[i].totalHeal = int.Parse(data[4 * (i + 1) + 2]);
            playerContainerData.Datas[i].speedMove = int.Parse(data[4 * (i + 1) + 3]);
        }
    }
}
