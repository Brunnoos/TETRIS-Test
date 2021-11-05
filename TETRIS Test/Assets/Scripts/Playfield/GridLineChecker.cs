using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLineChecker : MonoBehaviour
{
    private RaycastHit[] m_targetsHit;

    public void OnCheckLine()
    {
        m_targetsHit = CastRightRay();

        if (m_targetsHit.Length > 0)
        {
            //Debug.Log(name + " raycast: " + m_targetsHit.Length + " targets hit");

            if (m_targetsHit.Length == 10)
            {
                // Line is full
                //Debug.Log("Line is Full! Time to clean it");
            }
        }        
    }

    public RaycastHit[] CastRightRay()
    {       
        return Physics.RaycastAll(transform.position, Vector3.right);
    }
}
