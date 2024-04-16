using System;
using System.IO;
using System.Text;
using UnityEngine;
public class UtilsEncoding : MonoBehaviour
{
    private void Start()
    {
        string filepath = "data.txt";
        using (var stream = new FileStream(path: filepath, mode: FileMode.Open, access: FileAccess.ReadWrite, share: FileShare.Read))
        {
            Debug.Log(stream.Name);
            Debug.Log($"Kích thước stream {stream.Length} bytes / Vị trí {stream.Position}");
            Debug.Log($"Stream có thể : Đọc {stream.CanRead} -  Ghi {stream.CanWrite} - Seek {stream.CanSeek} - Timeout {stream.CanTimeout} ");
        }
        using (var stream = new FileStream(path: filepath, mode: FileMode.Create, access: FileAccess.Write, share: FileShare.None))
        {
            //Write BOM - UTF8
            Encoding encoding = Encoding.UTF8;
            byte[] bom = encoding.GetPreamble();
            stream.Write(bom, 0, bom.Length);

            string s1 = "Xuanthulab.net -  Xin chào các bạn! \n";
            string s2 = "Ví dụ - ghi file text bằng stream";

            // Encode chuỗi - lưu vào mảng bytes
            byte[] buffer = encoding.GetBytes(s1);
            stream.Write(buffer, 0, buffer.Length);  // lưu vào stream

            buffer = encoding.GetBytes(s2);
            stream.Write(buffer, 0, buffer.Length);  // lưu vào stream

        }
        using (var stream = new FileStream(path: filepath, mode: FileMode.Open, access: FileAccess.ReadWrite, share: FileShare.Read))
        {
            Debug.Log(stream.Name);
            Debug.Log($"Kích thước stream {stream.Length} bytes / Vị trí {stream.Position}");
            Debug.Log($"Stream có thể : Đọc {stream.CanRead} -  Ghi {stream.CanWrite} - Seek {stream.CanSeek} - Timeout {stream.CanTimeout} ");
        }
    }
    public static Encoding GetEncoding(Stream stream)
    {
        byte[] BOMBytes = new byte[4]; // mảng chứa 4 byte để làm bộ nhớ lưu byte đọc được
        int offset = 0; // vị trí (index) trong buffer - nơi ghi byte đầu tiên đọc được
        int count = 4; // đọc 4 byte
        int numberbyte = stream.Read(BOMBytes, offset, count); // bắt đầu đọc 4 đầu tiên lưu vào buffer

        if (BOMBytes[0] == 0xfe && BOMBytes[1] == 0xff)
        {
            stream.Seek(2, SeekOrigin.Begin); // Di chuyển về vị trí bắt đầu của dữ liệu (đã trừ BOM)
            return Encoding.BigEndianUnicode;
        }
        if (BOMBytes[0] == 0xff && BOMBytes[1] == 0xfe)
        {
            stream.Seek(2, SeekOrigin.Begin); // Di chuyển về vị trí bắt đầu của dữ liệu (đã trừ BOM)
            return Encoding.Unicode;
        }

        if (BOMBytes[0] == 0xef && BOMBytes[1] == 0xbb && BOMBytes[2] == 0xbf)
        {
            stream.Seek(3, SeekOrigin.Begin);
            return Encoding.UTF8;
        }
        if (BOMBytes[0] == 0x2b && BOMBytes[1] == 0x2f && BOMBytes[2] == 0x76)
        {
            stream.Seek(3, SeekOrigin.Begin);
            return Encoding.UTF7;
        }
        if (BOMBytes[0] == 0xff && BOMBytes[1] == 0xfe && BOMBytes[2] == 0 && BOMBytes[3] == 0)
        {
            stream.Seek(4, SeekOrigin.Begin);
            return Encoding.UTF32;
        }
        if (BOMBytes[0] == 0 && BOMBytes[1] == 0 && BOMBytes[2] == 0xfe && BOMBytes[3] == 0xff)
        {
            stream.Seek(4, SeekOrigin.Begin);
            return Encoding.GetEncoding(12001);
        }

        stream.Seek(0, SeekOrigin.Begin);
        return Encoding.Default;

    }
}