using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public Vector3 rotationPerSecond;

    void Update()
    {
        transform.Rotate(rotationPerSecond * Time.deltaTime);
        transform.localEulerAngles = new Vector3(
            transform.localEulerAngles.x % 360f,
            transform.localEulerAngles.y % 360f,
            transform.localEulerAngles.z % 360f
            );
    }
}
