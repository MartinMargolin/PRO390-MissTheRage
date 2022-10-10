using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject parent;
    [SerializeField] GibsManager gibsManager;
    [SerializeField] List<GameObject> parts;
   
    bool dontUpdate = false;

    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(parent);

        if (parent.GetComponent<Interactive>().broken && !dontUpdate)
        {
            //parent.SetActive(false);
            gameObject.SetActive(true);
            foreach (var part in parts)
            {
                part.AddComponent<MeshCollider>();
                part.GetComponent<MeshCollider>().convex = true;
                part.AddComponent<Rigidbody>();
                gibsManager.Add(part);

            }
            Debug.Log("BREAK COMPLETE");
            dontUpdate = true; 
        }
        

    }


    public void Make(GameObject p)
    {
        parent = p;
        Debug.Log(parent);
        gibsManager = GameObject.Find("GameManager").GetComponent<GibsManager>();
        Debug.Log(gibsManager);
        transform.position = parent.transform.position;
    }

    public void Despawn()
    {
        gibsManager.Remove(parts);
        foreach(var part in parts)
        {
            Destroy(part.gameObject);
        }
    }
    

}
   
