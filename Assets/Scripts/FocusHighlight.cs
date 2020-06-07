using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class FocusHighlight : MonoBehaviour, IMixedRealityFocusHandler
{
    private Color defaultColor;
    public Color focusColor;
    public Renderer backgroundRenderer;
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = backgroundRenderer.material.color;
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        backgroundRenderer.material.color = focusColor;
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        backgroundRenderer.material.color = defaultColor;
    }
}
