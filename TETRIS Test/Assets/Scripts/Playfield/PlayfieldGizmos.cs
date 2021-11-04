using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfieldGizmos : MonoBehaviour
{
    [SerializeField] private CurrentSide directionToDraw;
    [SerializeField] private Transform startPoint;
    [SerializeField] private float length;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
                
        switch (directionToDraw)
        {
            case CurrentSide.Right:
            case CurrentSide.Left:
                for (int i = 1; i <= transform.localScale.y; i++)
                {
                    Vector3 startPosition;
                    Vector3 endPosition;

                    startPosition = startPoint.position + new Vector3(0, i, 0);
                    endPosition = startPosition + new Vector3(length, 0, 0);

                    Gizmos.DrawLine(startPosition, endPosition);
                }

                break;

            case CurrentSide.Top:
            case CurrentSide.Bottom:
                for (int i = 1; i <= transform.localScale.x; i++)
                {
                    Vector3 startPosition;
                    Vector3 endPosition;

                    startPosition = startPoint.position + new Vector3(i, 0, 0);
                    endPosition = startPosition + new Vector3(0, length, 0);

                    Gizmos.DrawLine(startPosition, endPosition);
                }
                break;
        }
    }
}
