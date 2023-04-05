using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class input : MonoBehaviour
{
    public int sc = 0 ;
    public Text ma,levelTxt,hinttxt;
    int levelno = 0;
    int maxlevel = 0 ;

    string s = "";
    public GameObject winpageobj,playobj,skipobj,exitobj,homeobj,hintobj;
    public Sprite[] allPuzzles ;
    public Image puzzleImg ;
    public string[] trueans = { "10","20","30","40", "50", "60", "70", "80", "90", "100" };

    public string[] thint = { "sum", "2", "3", "4", "5" };

    public void OnEnable()
    {
        maxlevel = PlayerPrefs.GetInt("maxlevel", 0);
        levelno = PlayerPrefs.GetInt("levelno", 1);
        levelTxt.text = "PUZZLE" + levelno;
        puzzleImg.sprite = allPuzzles[levelno - 1];

        sc = PlayerPrefs.GetInt("score", sc);
        
    }

    public void onhintclick()
    {
        
        hintobj.SetActive(true);

        if (sc >= 20)
        {
            hinttxt.text = "" + thint[levelno-1];
            sc = sc - 20;
            PlayerPrefs.SetInt("score", sc);
        }
        else
        {
            hinttxt.text = "your score is not equal 20 \n Your score is = " + sc ;
        }
        
    }

    public void onhintclose()
    {
        hintobj.SetActive(false);
    }

    public void remove()
    {
        if (ma.text.Length > 0)
        {
            ma.text = ma.text.Remove(ma.text.Length - 1);
        }
    }
    public void numclick(int n)
    {
        ma.text = ma.text + n.ToString();
    }

    public void submit()
    {
        if (ma.text == trueans[levelno - 1] )
        {
            PlayerPrefs.DeleteKey("skip_" + levelno);
            if (maxlevel < levelno)
            {
                PlayerPrefs.SetInt("maxlevel", levelno);
            }
            levelno++;
            ma.text = s;
            sc = sc + 10;
            PlayerPrefs.SetInt("score",sc);
            PlayerPrefs.SetInt("levelno", levelno);
            winpageobj.SetActive(true);
            playobj.SetActive(false);
        }
        else
        {
            print("loss");
            ma.text = s;
        }
    }

    public void oncontinueclick()
    {
        playobj.SetActive(true);
        winpageobj.SetActive(false);

    }
    public void onmainmenuclick()
    {
        SceneManager.LoadScene("home");

    }

    public void onskipclick()
    {
        
      /*  levelno++;
            PlayerPrefs.SetInt("levelno", levelno);*/
        //    playobj.SetActive(false);
            skipobj.SetActive(true);

    }

    public void Onokclick()
    {
        PlayerPrefs.SetInt("skip_" + levelno, levelno);

        levelno++;
         if (maxlevel < levelno)
         {
             PlayerPrefs.SetInt("maxlevel", levelno);
         }
        //PlayerPrefs.SetInt("maxlevel", levelno);

        PlayerPrefs.SetInt("levelno", levelno);
        skipobj.SetActive(false);
        playobj.SetActive(false);
        playobj.SetActive(true);
    }

    public void oncancleclick()
    {
        playobj.SetActive(true);
        skipobj.SetActive(false);
    }

    public void onexitclick()
    {
        exitobj.SetActive(true);
    }

    public void onnoclick()
    {
        exitobj.SetActive(false);
        playobj.SetActive(true);
    }

    public void onyesclick()
    {
        exitobj.SetActive(false);
        SceneManager.LoadScene("home");
    }

   


}
