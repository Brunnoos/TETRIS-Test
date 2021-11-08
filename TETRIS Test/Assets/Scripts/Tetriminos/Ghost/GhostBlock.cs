using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : TetriminoBlock
{
    #region Inspector

    [SerializeField] private Vector3 defaultSize;

    #endregion

    #region Show and Hide

    public void Show()
    {
        transform.localScale = defaultSize;
    }

    public void Hide()
    {
        transform.localScale = Vector3.zero;
    }

    #endregion
}
