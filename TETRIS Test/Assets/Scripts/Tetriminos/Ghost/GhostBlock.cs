using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : TetriminoBlock
{
    [SerializeField] private Vector3 defaultSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        transform.localScale = defaultSize;
    }

    public void Hide()
    {
        transform.localScale = Vector3.zero;
    }
}
