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
    }
    private void Update()
    {
        rTransform.localPosition = Vector2.Lerp(rTransform.localPosition, counter.localPosition, moveSpeed * Time.deltaTime);
        if((rTransform.localPosition - counter.localPosition).magnitude < 10f)
        {
            ReachedTarget();
        }
    }
    private void ReachedTarget()
    {
        Destroy(gameObject);
    }
}
