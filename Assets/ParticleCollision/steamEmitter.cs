using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steamEmitter : MonoBehaviour
{
    public ParticleSystem waterEmitter;
    public List<ParticleSystem.EmitParams> listEmitParam = new List<ParticleSystem.EmitParams>();


    public void DoEmit()
    {
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = Color.red;
        emitParams.startSize = 0.2f;
        waterEmitter.Emit(emitParams, 10);
        listEmitParam.Add(emitParams);
        // waterEmitter.Play();
    }
    public void ClearParticle()
    {
        foreach (var x in listEmitParam)
        {
            Debug.Log(x.position);
        }
    }
}
