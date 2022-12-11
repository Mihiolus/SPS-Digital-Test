using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f, attackDistance = 1f, attackInterval;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Vector3 direction = Runner.position - transform.position;
        direction.y = 0;
        if (direction.magnitude <= attackDistance)
        {
            if (timer <= 0)
            {

                timer = attackInterval;
            }
            return;
        }
        direction.Normalize();
        direction *= speed;
        transform.Translate(direction * Time.deltaTime);
    }
}
