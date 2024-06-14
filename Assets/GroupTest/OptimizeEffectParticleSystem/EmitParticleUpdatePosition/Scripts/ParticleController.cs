using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public List<ParticleSystem.EmitParams> listEmitParam = new List<ParticleSystem.EmitParams>();
    public List<ParticleSystemData> currentParticleSystem;
    public List<Transform> listPosEmit = new List<Transform>();
    public void Start()
    {
        foreach (var particleData in currentParticleSystem)
        {
            StartCoroutine(UpdateSpawnParticle(particleData));
        }
    }
    IEnumerator UpdateSpawnParticle(ParticleSystemData particleSystemData)
    {
        yield return new WaitForSeconds(particleSystemData.RateSpawn);
        var emitParams = new ParticleSystem.EmitParams();
        foreach (var posEmit in listPosEmit)
        {
            if (particleSystemData.NumberEmit > 1)
            {
                for (int i = 0; i < particleSystemData.NumberEmit; i++)
                {
                    var centerPoint = particleSystemData.ParticleSystem.transform.InverseTransformPoint(posEmit.position);
                    var randomPos = (Vector2)centerPoint + UnityEngine.Random.insideUnitCircle * 0.2f;
                    emitParams.startColor = new Color(Color.white.r, Color.white.g, Color.white.b, particleSystemData.ColorAlpha);
                    emitParams.position = randomPos;
                    particleSystemData.ParticleSystem.Emit(emitParams, 1);
                }
            }
            else
            {
                var centerPoint = particleSystemData.ParticleSystem.transform.InverseTransformPoint(posEmit.position);
                emitParams.startColor = new Color(Color.white.r, Color.white.g, Color.white.b, particleSystemData.ColorAlpha);
                emitParams.position = centerPoint;
                particleSystemData.ParticleSystem.Emit(emitParams, 1);
            }
        }
        StartCoroutine(UpdateSpawnParticle(particleSystemData));
    }
}
[Serializable]
public class ParticleSystemData
{
    public ParticleSystem ParticleSystem;
    public int NumberEmit = 1;
    public float RateSpawn;
    public float ColorAlpha;
}
