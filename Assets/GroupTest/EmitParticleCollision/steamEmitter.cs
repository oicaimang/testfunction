using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steamEmitter : MonoBehaviour
{
    public ParticleSystem waterEmitter;
    public List<ParticleSystem.EmitParams> listEmitParam = new List<ParticleSystem.EmitParams>();
    List<Vector3> listPosEmit = new List<Vector3>();
    [SerializeField] float maxX = 10;
    [SerializeField] float minX = -10;
    [SerializeField] float maxY = 10;
    [SerializeField] float minY = -10;
    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            var x = Random.Range(minX, maxX);
            var y = Random.Range(minY, maxY);
            listPosEmit.Add(new Vector3(x, y, 0));
        }
    }
    public void DoEmit()
    {
        // var emitParams = new ParticleSystem.EmitParams();
        // emitParams.startColor = Color.red;
        // emitParams.startSize = 0.2f;
        waterEmitter.gameObject.SetActive(true);
        float countTimeWaitSpawn = 0;
        foreach (var x in listPosEmit)
        {
            countTimeWaitSpawn += 0.01f;
            StartCoroutine(WaitAndEmit(x, countTimeWaitSpawn));
        }
        // waterEmitter.Emit(new Vector3(0, 0, 0), new Vector3(0, 0, 0), 0.2f, 5, Color.red);
        // listEmitParam.Add(emitParams);
        // waterEmitter.Play();
    }

    ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
    IEnumerator WaitAndEmit(Vector3 posEmit, float timewait)
    {
        yield return new WaitForSeconds(timewait);
        float randomVelocityX = Random.Range(-0.2f, 0.2f);

        emitParams.startColor = Color.white;
        emitParams.startSize = 0.2f;
        emitParams.position = posEmit;
        emitParams.velocity = new Vector3(0, 0, 0);
        emitParams.angularVelocity3D = new Vector3(randomVelocityX, 0, 0);
        waterEmitter.Emit(emitParams, 1);
    }
    public void ClearParticle()
    {
        foreach (var x in listEmitParam)
        {
            Debug.Log(x.position);
        }
    }
}
