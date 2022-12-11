using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
    public float speed = 1f, attackDistance = 1f, attackInterval, damage = 1f;
    private float timer = 0;

    public EnemyManager manager;

    public ProgressBar healthBar;

    public float maxHealth;

    [SerializeField] private float health = 3;
    public float Health
    {
        get => health; set
        {
            health = value;
            healthBar.Progress = Mathf.Clamp01(health / maxHealth);
            if (health <= 0) manager.Despawn(transform);
        }
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
                Runner.instance.Health -= damage;
                timer = attackInterval;
            }
            return;
        }
        direction.Normalize();
        direction *= speed;
        transform.Translate(direction * Time.deltaTime);
    }
}
