using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoopGlowLight : MonoBehaviour
{
    [SerializeField] float maxIntensity = 10;
    [SerializeField] float timeLoop = 2;
    Material currentMat;
    float cacheStartValue;
    private void Start()
    {
        currentMat = GetComponent<Image>().material;

        if (currentMat != null)
        {
            OneTimeChangeIntensity(maxIntensity);
        }
    }
    private void OneTimeChangeIntensity(float targetValue)
    {
        cacheStartValue = currentMat.GetFloat("_Intensity");
        float x = cacheStartValue;
        DOTween.To(() => x, i => x = i, targetValue, timeLoop)
        .OnUpdate(() =>
        {
            currentMat.SetFloat("_Intensity", x);
        }).OnComplete(() =>
        {
            OneTimeChangeIntensity(cacheStartValue);
        });
    }
}
