using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    public Missile prefab;
    private List<Missile> actives = new List<Missile>();
    private Stack<Missile> inactives = new Stack<Missile>();

    public int initNumber = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initNumber; i++)
        {
            var m = Instantiate(prefab);
            m.gameObject.SetActive(false);
            inactives.Push(m);
        }
    }

    public Missile Get()
    {
        Missile m;
        if (inactives.Count == 0)
        {
            m = Instantiate(prefab);
        }
        else
        {
            m = inactives.Pop();
            m.gameObject.SetActive(true);
        }
        actives.Add(m);
        return m;
    }

    public void Release(Missile m)
    {
        if (actives.Contains(m))
        {
            m.gameObject.SetActive(false);
            actives.Remove(m);
            inactives.Push(m);
        }
    }
}
