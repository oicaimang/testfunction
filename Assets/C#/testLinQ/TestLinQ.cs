using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestLinQ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var brands = new List<Brand>()
        {
            new Brand{ID = 1, Name = "Công ty AAA"},
            new Brand{ID = 2, Name = "Công ty BBB"},
            new Brand{ID = 4, Name = "Công ty CCC"},
        };
        var productLinQs = new List<ProductLinQ>()
        {
            new ProductLinQ(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
            new ProductLinQ(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
            new ProductLinQ(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
            new ProductLinQ(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
            new ProductLinQ(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
            new ProductLinQ(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
            new ProductLinQ(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
        };

        // var ketqua = from product in productLinQs
        //              where product.Price == 400
        //              select product;

        // foreach (var product in ketqua)
        //     Debug.Log(product.ToString());
        // from ket hop

        // var ketqua = from product in productLinQs
        //               from color in product.Colors
        //               where product.Price < 500
        //               where color == "Vàng"
        //               select product;

        // foreach (var product in ketqua) Debug.Log(product.ToString());

        // orderby 
        // var ketqua = from product in productLinQs
        //              where product.Price <= 300
        //              orderby product.Price descending
        //              select product;
        // foreach (var product in ketqua) Debug.Log(product.ToString());

        //group by
        // var ketqua = from product in productLinQs
        //              where product.Price >= 400 && product.Price <= 500
        //              group product by product.Price;
        // var ketqua = from product in productLinQs
        //              where product.Price >= 400 && product.Price <= 500
        //              group product by product.Price into gr
        //              orderby gr.Key descending
        //              select gr;
        // foreach (var group in ketqua)
        // {
        //     // Key là giá trị dùng để phân loại (nhóm): là giá
        //     Debug.Log(group.Key);
        //     foreach (var product in group)
        //     {
        //         Debug.Log($"    {product.Name} - {product.Price}");
        //     }
        // }

        // let
        // var ketqua = from product in productLinQs                  // các sản phẩm trong products
        //              group product by product.Price into gr    // nhóm thành gr theo giá
        //              let count = gr.Count()                    // số phần tử trong nhóm
        //              select new
        //              {                              // trả về giá và số sản phầm có giá này
        //                  price = gr.Key,
        //                  number_product = count
        //              };

        // foreach (var item in ketqua)
        // {
        //     Debug.Log($"{item.price} - {item.number_product}");
        // }

        // inner join
        // var ketqua = from product in productLinQs
        //              join brand in brands on product.Brand equals brand.ID
        //              select new
        //              {
        //                  name = product.Name,
        //                  brand = brand.Name,
        //                  price = product.Price
        //              };

        // foreach (var item in ketqua)
        // {
        //     Debug.Log($"{item.name,10} {item.price,4} {item.brand,12}");
        // }

        // left join
        var ketqua = from product in productLinQs
                     join brand in brands on product.Brand equals brand.ID into t
                     from brand in t.DefaultIfEmpty()
                     select new
                     {
                         name = product.Name,
                         brand = (brand == null) ? "NO-BRAND" : brand.Name,
                         price = product.Price
                     };

        foreach (var item in ketqua)
        {
            Debug.Log($"{item.name,10} {item.price,4} {item.brand,12}");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
public class ProductLinQ
{
    public int ID { set; get; }
    public string Name { set; get; }
    public double Price { set; get; }
    public string[] Colors { set; get; }
    public int Brand { set; get; }
    public ProductLinQ(int id, string name, double price, string[] colors, int brand)
    {
        ID = id;
        Name = name;
        Price = price;
        Colors = colors;
        Brand = brand;
    }
    public override string ToString()
    {
        return $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
    }
}
public class Brand
{
    public string Name { set; get; }
    public int ID { set; get; }
}
