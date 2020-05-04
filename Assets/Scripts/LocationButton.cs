using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class LocationButton : MonoBehaviour, IMixedRealityPointerHandler
{
    public TextMeshPro textMesh;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        Debug.Log(textMesh.text);
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
