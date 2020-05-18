using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderManager : MonoBehaviour
{
    public BoundingBox boundingBox;
    public BoxCollider boxCollider;

    private void Start()
    {
        boundingBox = boundingBox ? boundingBox : GetComponent<BoundingBox>();
        boxCollider = boxCollider ? boxCollider : GetComponent<BoxCollider>();
    }

    private void Update()
    {
        boxCollider.enabled = boundingBox.Active;
    }
}
