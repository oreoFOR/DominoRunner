using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemImage : MonoBehaviour
{
    public RectTransform counter;
    RectTransform rTransform;
    public float moveSpeed;
    private void Start()
    {
        rTransform = GetComponent<RectTransform>();
        Invoke("ReachedTarget", 0.75f);
    }
    private void Update()
    {
        rTransform.localPosition = Vector2.Lerp(rTransform.localPosition, counter.localPosition, moveSpeed);
    }
    private void ReachedTarget()
    {
        Destroy(gameObject);
    }
}
