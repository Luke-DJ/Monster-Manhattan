﻿using UnityEngine;

// http://gamedesigntheory.blogspot.com/2010/09/controlling-aspect-ratio-in-unity.html
public class CameraAspectRatio : MonoBehaviour
{
    private void Start()
    {
        float targetAspect = 16.0f / 9.0f;
        // The game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetAspect;
        Camera camera = GetComponent<Camera>();

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}