using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBarScript : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 originalPosition;

    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    public void ScaleWidth(float newWidth)
    {
        float deltaWidth = newWidth - originalScale.x;
        transform.localScale = new Vector3(newWidth, originalScale.y, originalScale.z);
        transform.position -= new Vector3(0.5f, 0, 0);
    }
}
