using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int min = 1, max = 3;
    public float spawnDistance = 50f, spawnY = 0f;
    public Vector2 spawnZ, spawnXVar;
    public Transform prefab;
    private Stack<Transform> inactive = new Stack<Transform>();
    private List<Transform> active = new List<Transform>();
    public Vector2 enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < max; i++)
        {
            inactive.Push(Instantiate(prefab, transform));
            inactive.Peek().gameObject.SetActive(false);
        }
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < Random.Range(min, max); i++)
        {
            var enemy = inactive.Pop();
            active.Add(enemy);
            enemy.SetParent(null);
            enemy.gameObject.SetActive(true);
            Vector3 pos = new Vector3();
            pos.x = Runner.distanceTraveled + spawnDistance + Random.Range(spawnXVar.x, spawnXVar.y);
            pos.y = spawnY;
            pos.z = Random.Range(spawnZ.x, spawnZ.y);
            enemy.position = pos;
            Enemy script = enemy.GetComponent<Enemy>();
            script.manager = this;
            script.Health = Random.Range(enemyHealth.x, enemyHealth.y);
            script.maxHealth = script.Health;
        }
    }

    public void Despawn(Transform t)
    {
        if (active.Contains(t))
        {
            t.gameObject.SetActive(false);
            active.Remove(t);
            inactive.Push(t);
            t.SetParent(transform);
        }
        if (active.Count == 0)
        {
            Invoke("Spawn", 1f);
        }
    }
}
