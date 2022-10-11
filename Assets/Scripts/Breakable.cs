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
        Debug.Log(intact);

        if (intact.GetComponent<Interactive>().broken && !dontUpdate)
        {
            //intact.SetActive(false);
            transform.position = intact.transform.position;
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


   /* public void Make(GameObject p)
    {

        intact = p;
        Debug.Log(intact);
        gibsManager = GameObject.Find("GameManager").GetComponent<GibsManager>();
        Debug.Log(gibsManager);
       
    }*/

    public void Despawn()
    {
        gibsManager.Remove(parts);
        foreach(var part in parts)
        {
            Destroy(part.gameObject);
        }
    }
    

}
   
