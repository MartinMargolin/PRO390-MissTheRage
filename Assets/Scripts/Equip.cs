using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject selector;
    [SerializeField] List<GameObject> items;
    [SerializeField] List<GameObject> positions;
    [SerializeField] List<GameObject> icons;
    

    [SerializeField] bool selecting = false;
    [SerializeField] int test = 1;

    [SerializeField] public int selected;

    Selector s;

    Transform tempT;

    void Start()
    {
        s = selector.GetComponent<Selector>();
        UpdateItems();  
    }

    // Update is called once per frame
    void Update()
    {
        if (selecting)
        {

            switch (test)
            {
                case 1:
                    s.SetRotation(0);
                    selected = 1;
                    break;

                case 2:
                    s.SetRotation(45);
                    selected = 2;
                    break;

                case 3:
                    s.SetRotation(90);
                    selected = 3;
                    break;

                case 4:
                    s.SetRotation(135);
                    selected = 4;
                    break;

                case 5:
                    s.SetRotation(180);
                    selected = 5;
                    break;

                case 6:
                    s.SetRotation(225);
                    selected = 6;
                    break;

                case 7:
                    s.SetRotation(270);
                    selected = 7;
                    break;

                case 8:
                    s.SetRotation(315);
                    selected = 8;
                    break;
            }



        }
    }

    void UpdateItems()
    {
        int placement = 1;
     foreach(var item in items)
        {
            GameObject newIcon = Instantiate(item.GetComponent<Weapon>().icon);
            newIcon.transform.SetParent(this.gameObject.transform);
            newIcon.transform.localPosition = positions[placement - 1].transform.localPosition;
            newIcon.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            
            switch(placement)
            {
                case 1: newIcon.transform.localRotation = Quaternion.Euler(0, 0, 30); break;
                case 2: newIcon.transform.localRotation = Quaternion.Euler(0, 0, 70); break;
                case 3: newIcon.transform.localRotation = Quaternion.Euler(0, 0, 115); break;
                case 4: newIcon.transform.localRotation = Quaternion.Euler(0, 0, 157.5f); break;
                case 5: newIcon.transform.localRotation = Quaternion.Euler(0, 0, 204); break;
                case 6: newIcon.transform.localRotation = Quaternion.Euler(0, 0, 251); break;
                case 7: newIcon.transform.localRotation = Quaternion.Euler(0, 0, 294.5f); break;
                case 8: newIcon.transform.localRotation = Quaternion.Euler(0, 0, 341.6f); break;
            }
          
            placement++;
            icons.Add(newIcon);
        }
    }
}
