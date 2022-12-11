using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public static float distanceTraveled;
    private List<Transform> nearbyEnemies = new List<Transform>();
    public static Vector3 position;
    public float health = 10f;
    public float attackInterval = 1f;
    private float timer = 0f;
    public MissileManager missileManager;
    public float missileSpeed = 10f, launchAngle = 45f, damage = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        position = transform.position;
        if (nearbyEnemies.Count > 0)
        {
            if (timer <= 0)
            {
                LaunchAt(nearbyEnemies[0].GetComponent<Enemy>());
                timer = attackInterval;
            }
            return;
        }
        transform.Translate(5f * Time.deltaTime, 0f, 0f);
        distanceTraveled = transform.localPosition.x;
    }

    private void LaunchAt(Enemy enemy)
    {
        var missile = missileManager.Get();
        missile.transform.position = transform.position;
        Vector3 dist = enemy.transform.position - transform.position;
        dist.y = 0;
        float horizontalDist = dist.magnitude;
        missile.gravity = 2 * Mathf.Sin(Mathf.Deg2Rad * launchAngle) * Mathf.Cos(Mathf.Deg2Rad * launchAngle) * missileSpeed * missileSpeed / horizontalDist;
        missile.velocity = dist.normalized * missileSpeed;
        float yComp = missile.velocity.magnitude * Mathf.Sin(Mathf.Deg2Rad * launchAngle);
        Vector3 horComp = missile.velocity * Mathf.Cos(Mathf.Deg2Rad * launchAngle);
        missile.velocity = horComp;
        missile.velocity.y = yComp;
        missile.damage = damage;
        missile.manager = missileManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies") && !nearbyEnemies.Contains(other.transform))
        {
            nearbyEnemies.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        nearbyEnemies.Remove(other.transform);
    }
}
