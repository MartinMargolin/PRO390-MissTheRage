using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Menu menu;
  
    // LoadingScreen
    [SerializeField] GameObject titleName;
    [SerializeField] GameObject titleTitle;
    
    // Loaded Pieces
    [SerializeField] GameObject menuObject;
    [SerializeField] GameObject levelSelectObject;
    [SerializeField] GameObject optionsObject;
    [SerializeField] List<GameObject> levels = new List<GameObject>();
    


    public enum gameState
    {
        LOAD,
        MENU,
        OPTIONS,
        LEVELSELECT,
        PLAY,
        PAUSE,
    }

    public gameState state;
    
    
    bool done = false;
    int loadstate = 1;
    int txt = 0;
    float timer;


    
    // Start is called before the first frame update
    void Start()
    {
        state = gameState.LOAD;   
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        { 
        
            case gameState.LOAD:

                if (!done)
                {

                    switch (loadstate)
                    {
                        case 1:

                            titleName.gameObject.SetActive(true);
                            titleTitle.gameObject.SetActive(true);
                            timer = 0.5f;
                            loadstate = 2;
                            break;
                        case 2:
                            switch (txt)
                            {
                                case 0:
                                    if (timer > 0)
                                    {
                                        timer -= Time.deltaTime;
                                        //Debug.Log(timer);
                                    }
                                    else txt = 1;
                                    break;
                                case 1:
                                    if (titleName.gameObject.GetComponent<TMP_Text>().color.a < 1)
                                    {
                                        Color temp = titleName.gameObject.GetComponent<TMP_Text>().color;
                                        //Debug.Log(temp.a);
                                        temp.a += Time.deltaTime / 2;
                                        titleName.gameObject.GetComponent<TMP_Text>().color = temp;

                                    }
                                    else txt = 2;
                                    break;
                                case 2:
                                    if (titleName.gameObject.GetComponent<TMP_Text>().color.a > 0)
                                    {
                                        Color temp = titleName.gameObject.GetComponent<TMP_Text>().color;
                                        //Debug.Log(temp.a);
                                        temp.a -= Time.deltaTime / 2;
                                        titleName.gameObject.GetComponent<TMP_Text>().color = temp;
                                    }
                                    else { loadstate = 3; txt = 1; }

                                    break;

                            }
                            break;
                        case 3:
                            switch (txt)
                            {
                                case 1:
                                    if (titleTitle.gameObject.GetComponent<TMP_Text>().color.a <= 1)
                                    {
                                        Color temp = titleTitle.gameObject.GetComponent<TMP_Text>().color;
                                        temp.a += Time.deltaTime / 2;
                                        titleTitle.gameObject.GetComponent<TMP_Text>().color = temp;
                                    }
                                    else txt = 2;
                                    timer = 0.5f;
                                    break;
                                case 2:
                                    if (titleTitle.gameObject.GetComponent<TMP_Text>().color.a >= 0)
                                    {
                                        Color temp = titleTitle.gameObject.GetComponent<TMP_Text>().color;

                                        temp.a -= Time.deltaTime / 2;
                                        titleTitle.gameObject.GetComponent<TMP_Text>().color = temp;
                                    }
                                    else
                                    {
                                        if (timer > 0) timer -= Time.deltaTime;
                                        else done = true;
                                    }
                                    
                                    
                                    break;

                            }
                            break;
                    }

                }
                else
                {
                    
                    state = gameState.MENU;
                    menuObject.gameObject.SetActive(true);
                }
                break;

            case gameState.MENU:

                if (menuObject.activeSelf == false) menuObject.SetActive(true);
                if (levelSelectObject.activeSelf == true) levelSelectObject.SetActive(false);
                //if (optionsObject.activeSelf == true) optionsObject.SetActive(false);
                if (menu.topIsSelected) { state = gameState.LEVELSELECT; }
                if (menu.bottomIsSelected) { state = gameState.OPTIONS; }

                break;

            case gameState.LEVELSELECT:
                Debug.Log("Level");
                menuObject.gameObject.SetActive(false);
                levelSelectObject.gameObject.SetActive(true);
                break;

            case gameState.OPTIONS:
                Debug.Log("Options");
                menuObject.gameObject.SetActive(false);
                optionsObject.gameObject.SetActive(true);
                break;

            case gameState.PLAY:
                break;
        }


    }
}
