using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Popup : MonoBehaviour
{
    private TMP_Text label;
    private Vector3 velocity;
    public float lifetime = 2f;
    private float timer = 0f;
    private Despawn despawn;

    public delegate void Despawn(Popup p);

    public void Init(string text, Vector3 velocity, Despawn despawn)
    {
        if (!label)
            label = GetComponent<TMP_Text>();
        label.text = text;
        this.velocity = velocity;
        timer = 0f;
        this.despawn = despawn;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime, Space.World);
        if (timer >= lifetime)
        {
            despawn(this);
        }
    }
}
