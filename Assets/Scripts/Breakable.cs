using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public GameObject intact;
    [SerializeField] GibsManager gibsManager;
    [SerializeField] List<GameObject> parts;
   
    bool dontUpdate = false;

    void Start()
    {
        gibsManager = GameObject.Find("GameManager").GetComponent<GibsManager>();
    }
    
    // Update is called once per frame
    void Update()
    {


        if (!dontUpdate) if (intact.GetComponent<Interactive>().broken)
        {
            
            transform.position = intact.transform.position;
            gameObject.SetActive(true);
            foreach (var part in parts)
            {
                part.AddComponent<MeshCollider>();
                part.GetComponent<MeshCollider>().convex = true;
                part.AddComponent<Rigidbody>();
                gibsManager.Add(part);

            }
            Destroy(intact);
            dontUpdate = true; 
            
        }
        

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
   