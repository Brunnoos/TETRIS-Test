using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class UIElement : MonoBehaviour
{
    private Image m_image;
    private Button m_button;

    private bool m_highlighted = false;

    private void Start()
    {
        m_image = GetComponent<Image>();
        m_button = GetComponent<Button>();
    }

    private void Update()
    {
        if (m_highlighted)
            transform.localScale = Vector3.one * 1.2f;
        else
            transform.localScale = Vector3.one;
    }

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
}
