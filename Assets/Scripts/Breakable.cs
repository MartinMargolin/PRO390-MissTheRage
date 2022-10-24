using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public GameObject intact;
    [SerializeField] GibsManager gibsManager;
    [SerializeField] public List<GameObject> parts;
 

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
            transform.rotation = intact.transform.rotation;
           
            gameObject.SetActive(true);
            foreach (var part in parts)
            {
                part.AddComponent<BoxCollider>();
                part.AddComponent<Rigidbody>();
                gibsManager.Add(part);
                part.GetComponent<Rigidbody>().velocity = intact.GetComponent<Rigidbody>().velocity;

            }
           
            Destroy(intact);
            dontUpdate = true; 
            
        }
        if (parts.Count == 0) Destroy(gameObject);
        

    }

    public void Despawn()
    {
        gibsManager.Remove(parts);
        foreach(var part in parts)
        {
            parts.Remove(part);
            Destroy(part.gameObject);
        }
    }
    

}
   