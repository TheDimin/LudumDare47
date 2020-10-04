using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class TextScroller : MonoBehaviour
{
    [SerializeField] private float speed;

    private RectTransform TextObj;
    private RectTransform endPos;
    private Vector3 startLocation;
    private float restartLocation;
    private void Awake()
    {
        TextObj = transform.GetChild(0) as RectTransform;
        Debug.Assert(TextObj != null, nameof(TextObj) + " != null");
        endPos = TextObj.GetChild(0) as RectTransform;

        restartLocation = TextObj.position.y - endPos.position.y;

        startLocation = TextObj.position;
    }

    private void OnEnable()
    {
        TextObj.position = startLocation;
    }

    void Update()
    {
        TextObj.position += Vector3.up * (speed * Time.deltaTime);
        if ((endPos.position.y - startLocation.y) > 0)
            TextObj.position = startLocation + Vector3.down * (restartLocation * .4f);
    }
}
