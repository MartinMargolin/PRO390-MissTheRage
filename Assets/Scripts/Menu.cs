using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] GameObject Top;
    [SerializeField] public bool topIsSelected = false;
    [SerializeField] GameObject PlayButton;

    [SerializeField] GameObject Bottom;
    [SerializeField] public bool bottomIsSelected = false;
    [SerializeField] GameObject OptionsButton;
 
    public float waitTimer;

    public bool launched = false;


    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        if (topIsSelected)
        {
           
            if (!launched)
            {
                waitTimer = 1;
                Top.GetComponent<Rigidbody>().useGravity = true;
                Top.GetComponent<Rigidbody>().velocity = Vector3.up * 7 + Vector3.right * 5 + Vector3.forward * 5;
                Top.GetComponent<Rigidbody>().AddTorque(Vector3.one * 100);
                launched = true;
                PlayButton.SetActive(false);
            }
            if (waitTimer > 0) { waitTimer -= Time.deltaTime; } else gameManager.state = GameManager.gameState.LEVELSELECT;
            
        }

        if (bottomIsSelected)
        {
            if (!launched)
            {
                waitTimer = 1;
                Bottom.GetComponent<Rigidbody>().useGravity = true;
                Bottom.GetComponent<Rigidbody>().velocity = Vector3.up * 7 + Vector3.right * 5 + Vector3.forward * 5;
                Bottom.GetComponent<Rigidbody>().AddTorque(Vector3.one * 100);
                launched = true;
                OptionsButton.SetActive(false);
            }
            if (waitTimer > 0) { waitTimer -= Time.deltaTime; } else gameManager.state = GameManager.gameState.OPTIONS;
        }
    }
}
