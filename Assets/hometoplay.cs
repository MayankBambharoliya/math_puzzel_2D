using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class hometoplay : MonoBehaviour
{

    public GameObject homeobj, playobj, levelsobj, winpageobj;
        
    public void onContinueclick()
    {
        SceneManager.LoadScene("play");
    }

    public void onPuzzlesClick()
    {
        SceneManager.LoadScene("level");
    }

    /* public void onlevelClick(int no)
     {
         PlayerPrefs.SetInt("levelno",no);
         playobj.SetActive(true);
         levelsobj.SetActive(false);
     }*/
    public void ongotohomeclick()
    {
        SceneManager.LoadScene("home");
    }
}
