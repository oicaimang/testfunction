using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public List<ParticleSystem.EmitParams> listEmitParam = new List<ParticleSystem.EmitParams>();
    public List<ParticleSystemData> currentParticleSystem;
    public List<Transform> listPosEmit = new List<Transform>();
    public void StartParticle()
    {
        StartCoroutine(UpdateSpawnParticle());
    }
    IEnumerator UpdateSpawnParticle()
    {
        yield return new WaitForSeconds(0.1f);
        float countTimeWaitSpawn = 0;
        foreach (var x in listPosEmit)
        {
            countTimeWaitSpawn += 0.01f;
            StartCoroutine(WaitAndEmit(x.position, countTimeWaitSpawn));
        }
        StartCoroutine(UpdateSpawnParticle());
    }
    IEnumerator WaitAndEmit(Vector3 posEmit, float timewait)
    {
        yield return new WaitForSeconds(timewait);
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.position = new(posEmit.x, 0, posEmit.y);
        foreach (var x in currentParticleSystem)
        {
            emitParams.startColor = new Color(Color.white.r, Color.white.g, Color.white.b, x.ColorAlpha);

            StartCoroutine(WaitNextEmit(x, emitParams));
        }
    }
    IEnumerator WaitNextEmit(ParticleSystemData particleSystemData, ParticleSystem.EmitParams emitParams)
    {
        float countTimeWaitSpawnOneEmitParam = 0;
        countTimeWaitSpawnOneEmitParam += particleSystemData.RateSpawn;
        yield return new WaitForSeconds(countTimeWaitSpawnOneEmitParam);
        particleSystemData.ParticleSystem.Emit(emitParams, 1);
    }
    // public void ClearParticle()
    // {
    //     foreach (var x in listEmitParam)
    //     {
    //         Debug.Log(x.position);
    //     }
    // }
}
[Serializable]
public class ParticleSystemData
{
    public ParticleSystem ParticleSystem;
    public float RateSpawn;
    public float ColorAlpha;
}
