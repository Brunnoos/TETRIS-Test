using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridChecker : MonoBehaviour
{
    [SerializeField] private List<GridLineChecker> linesToCheck;
    
    
    public void CheckLines()
    {
        foreach(GridLineChecker line in linesToCheck)
        {
            line.OnCheckLine();
        }
    }
}
