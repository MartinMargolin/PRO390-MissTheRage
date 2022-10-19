using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] bool left_right;
    [SerializeField] Transform holdingTransform;

    bool grabbing = false;
    GameObject holding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbing)
        {
            //Debug.Log(holding);
           

            holding.transform.position = holdingTransform.position;
            holding.transform.rotation = holdingTransform.rotation;
          
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon" && !grabbing)
        {
            other.transform.SetParent(other.gameObject.transform);
            if (!other.TryGetComponent<Weapon>(out Weapon t))
            {
                other.transform.position = holdingTransform.position;
                other.transform.rotation = holdingTransform.rotation;
                other.GetComponentInChildren<Rigidbody>().useGravity = false;
                other.GetComponentInChildren<Rigidbody>().isKinematic = true;
              
               
            }
            else
            {
                other.GetComponent<Weapon>().holding.transform.position = holdingTransform.position;
                other.GetComponent<Weapon>().holding.transform.rotation = holdingTransform.rotation;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                
              
                
            }

          

            Debug.Log("Grabbed: " + other.name);
            holding = other.gameObject;
            grabbing = true;
        }
    }

    
}
