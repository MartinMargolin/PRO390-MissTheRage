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
    [SerializeField] GameObject island;

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
                                        Debug.Log(timer);
                                    }
                                    else txt = 1;
                                    break;
                                case 1:
                                    if (titleName.gameObject.GetComponent<TMP_Text>().color.a < 1)
                                    {
                                        Color temp = titleName.gameObject.GetComponent<TMP_Text>().color;
                                        Debug.Log(temp.a);
                                        temp.a += Time.deltaTime / 2;
                                        titleName.gameObject.GetComponent<TMP_Text>().color = temp;

                                    }
                                    else txt = 2;
                                    break;
                                case 2:
                                    if (titleName.gameObject.GetComponent<TMP_Text>().color.a > 0)
                                    {
                                        Color temp = titleName.gameObject.GetComponent<TMP_Text>().color;
                                        Debug.Log(temp.a);
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
                                    break;
                                case 2:
                                    if (titleTitle.gameObject.GetComponent<TMP_Text>().color.a >= 0)
                                    {
                                        Color temp = titleTitle.gameObject.GetComponent<TMP_Text>().color;

                                        temp.a -= Time.deltaTime / 2;
                                        titleTitle.gameObject.GetComponent<TMP_Text>().color = temp;
                                    }
                                    else done = true;
                                    break;

                            }
                            break;
                    }

                }
                else
                {
                    state = gameState.MENU;
                    island.gameObject.SetActive(true);
                }
                break;

            case gameState.MENU:
                if (menu.topIsSelected) { state = gameState.LEVELSELECT; }
                if (menu.bottomIsSelected) { state = gameState.OPTIONS; }

                break;

            case gameState.LEVELSELECT:
                Debug.Log("Level");
                break;

            case gameState.OPTIONS:
                Debug.Log("Options");
                break;
        }


    }
}
