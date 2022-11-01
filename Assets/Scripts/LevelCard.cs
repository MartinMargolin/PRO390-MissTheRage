using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCard : MonoBehaviour
{
    [SerializeField] GameObject card;

    public bool selected = false;
    public int level = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            card.GetComponent<Rigidbody>().isKinematic = false;
            card.GetComponent<Rigidbody>().velocity = Vector3.up * 7 + Vector3.left * 5 + Vector3.back * 5;
            card.GetComponent<Rigidbody>().AddTorque(Vector3.one * 100);
        }
    }

}
