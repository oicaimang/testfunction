using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FileStreamTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = "data.dat";
        using var stream = new FileStream(path: path, FileMode.Open);
        data data = new data();
        // data.Save(stream);
        data.Restore(stream);
        Debug.Log(data.ID + " " + data.Price + " " + data.Name);
    }
}
class data
{
    public int ID { get; set; }
    public double Price { get; set; }
    public string Name { get; set; }
    public void Save(Stream stream)
    {
        // int -->4 byte
        var bytes_id = BitConverter.GetBytes(ID);
        stream.Write(bytes_id, 0, 4);

        // double -->8 byte
        var bytes_price = BitConverter.GetBytes(Price);
        stream.Write(bytes_price, 0, 8);

        // Chuoi Name
        var bytes_name = Encoding.UTF8.GetBytes(Name);
        var bytes_length = BitConverter.GetBytes(bytes_name.Length);
        stream.Write(bytes_length, 0, 4);
        stream.Write(bytes_name, 0, bytes_name.Length);
    }
    public void Restore(Stream stream)
    {
        // int -->4 byte
        var bytes_id = new byte[4];
        stream.Read(bytes_id, 0, 4);
        ID = BitConverter.ToInt32(bytes_id, 0);
        // double -->8 byte
        var bytes_price = new byte[8];
        stream.Read(bytes_price, 0, 8);
        Price = BitConverter.ToDouble(bytes_price, 0);

        // Chuoi Name
        var bytes_leng = new byte[4];
        stream.Read(bytes_leng, 0, 4);
        int leng = BitConverter.ToInt32(bytes_leng, 0);

        var bytes_name = new byte[leng];
        stream.Read(bytes_name, 0, leng);
        Name = Encoding.UTF8.GetString(bytes_name, 0, leng);
    }
}
