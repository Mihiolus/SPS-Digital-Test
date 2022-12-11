using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public static float distanceTraveled;
    private List<Transform> nearbyEnemies = new List<Transform>();
    public static Vector3 position;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        if (nearbyEnemies.Count > 0)
        {
            return;
        }
        transform.Translate(5f * Time.deltaTime, 0f, 0f);
        distanceTraveled = transform.localPosition.x;
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
