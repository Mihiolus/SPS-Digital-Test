using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Vector3 velocity;
    public float damage = 1f, gravity;
    public MissileManager manager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime, Space.World);
        velocity.y -= gravity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.activeSelf)
        {
            return;
        }
        IDamageable d = other.GetComponent<IDamageable>();
        if (d != null)
        {
            d.Health -= damage;
            manager.Release(this);
        }
    }
}
