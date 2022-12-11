using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
    public float speed = 1f, attackDistance = 1f, attackInterval;
    private float timer = 0;

    [SerializeField] private float health = 3;
    public float Health { get => health; set { health = value; Debug.Log(health); } }


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
