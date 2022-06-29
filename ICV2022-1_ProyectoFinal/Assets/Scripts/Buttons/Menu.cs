using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject store;
    public GameObject info;

    public void showStore(){
        store.SetActive(true);
    }

    public void hideStore() {
        store.SetActive(false);
    }

    public void showInfo()
    {
        info.SetActive(true);
    }

    public void hideInfo()
    {
        info.SetActive(false);
    }
}
