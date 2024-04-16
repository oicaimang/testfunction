using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSortedList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SortedList<string, Product2> products = new SortedList<string, Product2>();
        products["sanpham1"] = new Product2() { Name = "Iphone", Price = 1000, Origin = "China" };
        products["sanpham2"] = new Product2() { Name = "Samsung", Price = 900, Origin = "China" };
        products.Add("sanpham3", new Product2() { Name = "Nokia", Price = 800, Origin = "China" });

        // var p = products["sanpham2"];
        // Debug.Log(p.Name);
        // var keys = products.Keys;
        // foreach (var x in keys)
        // {
        //     var product = products[x];
        //     Debug.Log(product.Name);
        // }
        foreach (KeyValuePair<string, Product2> item in products)
        {
            var key = item.Key;
            var val = item.Value;
            Debug.Log($"{key}-{val.Name}");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
public class Product2
{
    public string Name { set; get; }
    public int Price { set; get; }
    public string Origin { set; get; }
}
