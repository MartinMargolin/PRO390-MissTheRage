using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibsManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Options options;
    [SerializeField] List<GameObject> gibs;

    [SerializeField] bool testClear = false;

    void Start()
    {
        gibs.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        while (gibs.Count > options.maxGibs)
        {
            gibs[0].GetComponentInParent<Breakable>().parts.Remove(gibs[0]);
            Destroy(gibs[0]);
            gibs.RemoveAt(0);
        }

        if (testClear == true)
        {
            Reset();
            testClear = false;
        }
    }


    public void Reset()
    {
        if (gibs.Count > 0)
        {
            foreach (var gib in gibs)
            {
                gib.GetComponentInParent<Breakable>().parts.Remove(gib);
                Destroy(gib.gameObject);
            }
            gibs.Clear();
            
        }
    }


    public void Remove(List<GameObject> parts)
    {
        foreach(var part in parts)
        {
           
            gibs.Remove(part);
        }
    }

    public void Add(GameObject part)
    {
        gibs.Add(part);
    }

    public void Add(List<GameObject> parts)
    {
        foreach (var part in parts)
        {
            gibs.Add(part);
        }
    }

}
