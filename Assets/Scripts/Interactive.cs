using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    
    [SerializeField] GameObject destroyed;
    [SerializeField] public int durability;
    [SerializeField] public bool broken = false;
    private bool dontUpdate = false;

    [SerializeField] public ObjectType type; 

    
    // Start is called before the first frame update
    void Start()
    {

    

    }

    // Update is called once per frame
    void Update()
    {
        if (durability == 0 && !dontUpdate)
        {
              switch (type)
             {
                 case ObjectType.BREAKABLE:
                     Instantiate<GameObject>(destroyed).GetComponent<Breakable>().intact = gameObject;
                     broken = true;
                     gameObject.SetActive(false);
                     dontUpdate = true;
                     break;
                 case ObjectType.DAMAGABLE:
                     Instantiate<GameObject>(destroyed).GetComponent<Damagable>().intact = gameObject;
                     broken = true;
                     gameObject.SetActive(false);
                     dontUpdate = true;
                     break;
             }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon" && durability > 0) durability--;
        // if not 0 play hit sound if 0 play break sound
    }
}
