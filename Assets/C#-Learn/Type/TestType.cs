using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
public class TestType : MonoBehaviour
{
    [Mota("Lop chua thong tin ve User ")]
    public class User
    {
        // [Mota("Du lieu ten")]
        public string Name { get; set; }
        // [Mota("Du lieu tuoi")]
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Obsolete("Phuong thuc nay da loi thoi. Hay dung phuong thuc ShowInfor")]
        public void PrintInfor() => Debug.Log(Name + " " + Age);

    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class MotaAttribute : Attribute
    {
        public string Thongtinchitiet { get; set; }
        public MotaAttribute(string _Thongtinchitiet)
        {
            Thongtinchitiet = _Thongtinchitiet;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        User user = new User()
        {
            Name = "Quyet",
            Age = 27,
            PhoneNumber = "0372578249",
            Email = "nguyenducquyet175@gmail.com"

        };
        var properties = user.GetType().GetProperties();
        foreach (PropertyInfo propertyInfo in properties)
        {
            string name = propertyInfo.Name;
            // propertyInfo only save property and when getvalue you can take property of some object have same class
            // var value1 = propertyInfo.GetValue(user1);
            var value = propertyInfo.GetValue(user);

            foreach (var attr in propertyInfo.GetCustomAttributes(false))
            {
                MotaAttribute mota = attr as MotaAttribute;
                if (mota != null)
                {
                    Debug.Log($"{name}-{mota.Thongtinchitiet}-{value}");
                }
            }
        }
        user.PrintInfor();

        // User user1 = new User()
        // {
        //     Name = "Quyet1",
        //     Age = 271,
        //     PhoneNumber = "03725782491",
        //     Email = "nguyenducquyet175@gmail.com1"

        // };
        // int a = 1;
        // var t = a.GetType();
        // Debug.Log(t.FullName);
        // int[] a = { 1, 2, 3 };
        // Type t = a.GetType();
        // Debug.Log(t.FullName);
        // Debug.Log("________________Cac thuoc tinh");
        // t.GetProperties().ToList().ForEach(
        // (_) =>
        // {
        //     Debug.Log(_.Name);
        // });
        // Debug.Log("________________Cac truong du lieu");
        // t.GetFields().ToList().ForEach(
        // (_) =>
        // {
        //     Debug.Log(_.Name);
        // });
        // Debug.Log("________________Cac phuong thuc");
        // t.GetMethods().ToList().ForEach(
        // (_) =>
        // {
        //     Debug.Log(_.Name);
        // });
    }
}