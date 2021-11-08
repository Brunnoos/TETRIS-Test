using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class UIElement : MonoBehaviour
{
    #region Internal

    private Button m_button;

    private bool m_highlighted = false;

    #endregion

    #region UNITY

    private void Start()
    {
        m_button = GetComponent<Button>();
    }

    private void Update()
    {
        if (m_highlighted)
            transform.localScale = Vector3.one * 1.2f;
        else
            transform.localScale = Vector3.one;
    }

    #endregion

    #region Actions

    public void OnConfirm()
    {
        m_button.onClick.Invoke();
    }

    public void HighlightElement()
    {
        m_highlighted = true;
    }

    public void UnhighlightElement()
    {
        m_highlighted = false;
    }

    #endregion
}
