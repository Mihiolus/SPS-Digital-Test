using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int min = 1, max = 3;
    public float spawnDistance = 50f, spawnY = 0f;
    public Vector2 spawnZ;
    public Transform prefab;
    private Stack<Transform> inactive = new Stack<Transform>();
    private List<Transform> active = new List<Transform>();

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

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn()
    {
        for (int i = 0; i < Random.Range(min, max); i++)
        {
            var enemy = inactive.Pop();
            enemy.SetParent(null);
            enemy.gameObject.SetActive(true);
            Vector3 pos = new Vector3();
            pos.x = Runner.distanceTraveled + spawnDistance;
            pos.y = spawnY;
            pos.z = Random.Range(spawnZ.x, spawnZ.y);
            enemy.position = pos;
        }
    }
}
