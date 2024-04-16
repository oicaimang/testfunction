using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCancleFunc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Product p = new Product("ABC");  // Tạo đối tượng, biến p tham chiếu đến đối tượng
        p = null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
//DestructorExample.cs
class Product
{
    private string product_name;
    public Product(string name)
    {
        this.product_name = name;
        Debug.Log("Tạo - " + product_name);
    }
    ~Product()
    {
        Debug.Log("Hủy - " + product_name);
    }
}
