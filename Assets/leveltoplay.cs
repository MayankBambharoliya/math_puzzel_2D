using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class leveltoplay : MonoBehaviour
{


    int i ,levelno = 0;
    int maxlevel;
    public GameObject levelobj,level1obj; // homeobj, playobj ; 
    public Button[] allbtns;
    public Sprite ticksign;
    

    private void OnEnable()
    {
   
        maxlevel = PlayerPrefs.GetInt("maxlevel", 0);
        print(maxlevel);
        for (int i = 0; i <= maxlevel; i++)
        {
            allbtns[i].interactable = true;
            if (i == maxlevel)
            {
                allbtns[i].GetComponent<Image>().sprite = null;
                allbtns[i].GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }
            else
            {
                if (PlayerPrefs.HasKey("skip_" + (i + 1)))
                {
                    
                    allbtns[i].GetComponent<Image>().sprite = null;
                    allbtns[i].GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                    


                    /*
                                        playobj.SetActive(false);
                                        playobj.SetActive(true);*/
                }
                else
                {
                    allbtns[i].GetComponent<Image>().sprite = ticksign;
                }
            }
            allbtns[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
        }
    }

    public void onlevelClick(int no)
    {
        PlayerPrefs.SetInt("levelno", no);
        SceneManager.LoadScene("play");
       // playobj.SetActive(true);
       // levelobj.SetActive(false);
    }
    public void Onbackclick()
    {
        SceneManager.LoadScene("home");
       // homeobj.SetActive(true);
       // levelobj.SetActive(false);
    }

    public void Onnextpageclick()
    {
        level1obj.SetActive(true);
        levelobj.SetActive(false);
    }
    public void Onprevpageclick()
    {
        level1obj.SetActive(false);
        levelobj.SetActive(true);
    }
}
