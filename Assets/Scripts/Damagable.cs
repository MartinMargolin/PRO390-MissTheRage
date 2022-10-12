using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
 
    [SerializeField] public GameObject intact;




    bool dontUpdate = false;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!dontUpdate) if (intact.GetComponent<Interactive>().broken)
            {
                transform.position = intact.transform.position;
                transform.rotation = intact.transform.rotation;
                gameObject.SetActive(true);
                Destroy(intact);
                dontUpdate = true;
            }
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }
}
