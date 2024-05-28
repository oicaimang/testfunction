using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveByMouse : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public NavMeshAgent m_Agent;
    RaycastHit2D m_HitInfo = new RaycastHit2D();

    void Start()
    {
        m_Agent.enabled = true;
        m_Agent.updateRotation = false;
        m_Agent.updateUpAxis = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log(cam);
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            m_HitInfo = Physics2D.Raycast(ray.origin, ray.direction);
            // m_Agent.destination = m_HitInfo.point;
            Debug.Log(m_Agent);
            m_Agent.SetDestination(m_HitInfo.point);
        }
    }
}
