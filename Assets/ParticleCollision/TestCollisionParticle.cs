using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollisionParticle : MonoBehaviour
{
    public steamEmitter steamEmitter;
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("here");
        steamEmitter.ClearParticle();
    }
}
