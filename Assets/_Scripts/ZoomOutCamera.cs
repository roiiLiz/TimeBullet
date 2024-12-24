using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutCamera : MonoBehaviour
{
    [SerializeField]
    private float startingCameraSize;
    [SerializeField]
    private float endingCameraSize;
    [SerializeField]
    private float timeBetweenSizesInSeconds;

    private new Camera camera;

    void Awake()
    {
        camera = GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        camera.orthographicSize = startingCameraSize;
        StartCoroutine(BeginZoom());
    }

    private IEnumerator BeginZoom()
    {
        while (camera.orthographicSize < endingCameraSize)
        {
            camera.orthographicSize += endingCameraSize / timeBetweenSizesInSeconds * Time.deltaTime;
            yield return null;
        }
    }

    
}
