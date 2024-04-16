using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTextRemote : MonoBehaviour
{
    [SerializeField] private GameObject loadingImageGo;
    [SerializeField] private Text textContent;

    private static readonly HttpClient Client = new HttpClient();

    // private async void Start()
    // {
    //     loadingImageGo.SetActive(true);
    //     textContent.gameObject.SetActive(false);
    //     var content = await TranslateAsync(Data.AndroidContentUpdate, LocalizationManager.CurrentLanguageCode);
    //     loadingImageGo.SetActive(false);
    //     textContent.gameObject.SetActive(true);
    //     textContent.text = content;
    // }

    // public async Task<string> TranslateAsync(string text, string targetLanguage, string sourceLanguage = "auto")
    // {
    //     var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={sourceLanguage}&tl={targetLanguage}&dt=t&q={Uri.EscapeDataString(text)}";

    //     var response = await Client.GetAsync(url);
    //     response.EnsureSuccessStatusCode();

    //     Debug.LogWarning(response.EnsureSuccessStatusCode());

    //     string responseBody = await response.Content.ReadAsStringAsync();
    //     var responseJson = JArray.Parse(responseBody);
    //     return (string)responseJson[0][0]?[0];
    // }
}
