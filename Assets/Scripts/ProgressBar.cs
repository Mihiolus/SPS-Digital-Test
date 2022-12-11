using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public RectTransform fill;
    private float progress;
    public float Progress
    {
        get => progress; set
        {
            progress = value;
            Vector2 scale = fill.localScale;
            scale.x = progress;
            fill.localScale = scale;
        }
    }
}
