using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public int Switcher = 0;
    public GameObject SC0;
    public GameObject SC1;
    public GameObject SC2;
    public GameObject SC3;
    public GameObject SC4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            Switcher += 1;
        }
        if (Input.GetButtonDown("SwitchBack"))
        {
            Switcher -= 1;
        }
        if (Switcher == -1)
        {
            Switcher = 4;
        }
        if (Switcher == 5)
        {
            Switcher = 0;
        }
        if (Switcher == 0)
        {
            SC4.SetActive(false);
            SC0.SetActive(true);
            SC1.SetActive(false);
        }
        if (Switcher == 1)
        {
            SC0.SetActive(false);
            SC1.SetActive(true);
            SC2.SetActive(false);
        }
        if (Switcher == 2)
        {
            SC1.SetActive(false);
            SC2.SetActive(true);
            SC3.SetActive(false);
        }
        if (Switcher == 3)
        {
            SC2.SetActive(false);
            SC3.SetActive(true);
            SC4.SetActive(false);
        }
        if (Switcher == 4)
        {
            SC3.SetActive(false);
            SC4.SetActive(true);
            SC0.SetActive(false);
        }
    }
}
