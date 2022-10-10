using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{

    [SerializeField] GameObject destroyed;
    [SerializeField] public int durability;
    [SerializeField] public bool broken = false;
    private bool dontUpdate = false;
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        if (durability == 0 && !dontUpdate)
        {

            Debug.Log("BREAK");
            /*Instantiate(destroyed);*/
            //  GameObject.Instantiate(destroyed);  
            Instantiate<GameObject>(destroyed);
            destroyed.GetComponent<Breakable>().Make(this.gameObject);
            broken = true;
            gameObject.SetActive(false);
            dontUpdate = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon" && durability > 0) durability--;
    }
}
