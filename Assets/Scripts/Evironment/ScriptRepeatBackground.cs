using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScriptRepeatBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0f);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
