using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TestDoPathCubicBezier : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform From;
    [SerializeField] private Transform To;
    void Start()
    {
        Vector3[] waypoint = new[] { From.position,
        new Vector3(From.position.x+2,From.position.y-2),
        new Vector3(From.position.x,From.position.y-2,0),
        To.position,
        new Vector3(From.position.x,From.position.y+2,0),
        new Vector3(To.position.x-2,To.position.y,0)};
        transform.DOPath(waypoint, 2, PathType.CubicBezier).SetEase(Ease.Linear);
    }
}
