using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitation : MonoBehaviour
{

    public float increment = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //   (Vector3.one * Mathf.Sin(Time.time) / 8) + Vector3.one;
        Vector3 position = this.gameObject.transform.position;
        position.y += Mathf.Sin(Time.time) / 1000;
        this.gameObject.transform.position = position;


        //Debug.Log(Vector3.one * Mathf.Sin(Time.time));

    }
}
