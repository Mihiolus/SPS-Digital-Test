using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    private List<Popup> active = new List<Popup>();
    private Stack<Popup> inactive = new Stack<Popup>();

    public int startingNumber = 10;
    public Popup prefab;
    private static PopupManager instance;
    public float popupSpeed = 2f, popupAngle = 30f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        for (int i = 0; i < startingNumber; i++)
        {
            var p = Instantiate(prefab);
            p.gameObject.SetActive(false);
            inactive.Push(p);
        }
    }

    public static void Spawn(Vector3 position, string text)
    {
        Popup p;
        if (instance.inactive.Count == 0)
        {
            p = Instantiate(instance.prefab);
        }
        else
        {
            p = instance.inactive.Pop();
            p.gameObject.SetActive(true);
        }
        instance.active.Add(p);
        p.transform.position = position;

        float angle = Random.Range(-instance.popupAngle, instance.popupAngle);
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        p.Init(text, rotation * Vector3.up * instance.popupSpeed, p => instance.Despawn(p));
    }

    private void Despawn(Popup popup)
    {
        if (active.Contains(popup))
        {
            popup.gameObject.SetActive(false);
            active.Remove(popup);
            inactive.Push(popup);
        }
    }
}
