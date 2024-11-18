using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Highscore : MonoBehaviour
{
    public TMP_InputField inputField;
    public  TextMeshProUGUI nname;
    public  TextMeshProUGUI first;
    public TextMeshProUGUI first2;
    public TextMeshProUGUI High;
    public GameObject Back;
    public GameObject input;
    public GameObject confirm;
    public GameObject play;
    public GameObject HIGH_bot;
    public GameObject Quit;
    public static string fir;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        inputField.enabled = false;
        input.SetActive(false);
        confirm.SetActive(false);
        first.enabled = false;
        first2.enabled = false;
        High.enabled = false;
        Back.SetActive(false);
        first2.text= "";





    }
    public void PlayGame()
    {
        input.SetActive(true);
        inputField.enabled = true;
        confirm.SetActive(true);
        Back.SetActive(true);
        play.SetActive(false);
        HIGH_bot.SetActive(false);
        Quit.SetActive(false);

    }
    public void Highscore_button() 
    {
        first.enabled = true;
        first2.enabled = true;
        High.enabled = true;
        Back.SetActive(true);
        play.SetActive(false);
        HIGH_bot.SetActive(false);
        Quit.SetActive(false);
    }

    public void OnApplicationQuit()
    {
        Debug.Log("Quit!!");
        Application.Quit();

    }
    public void Confirm()
    {
        if (inputField.text != "") 
        {
           nname.text = inputField.text;
            fir = nname.text;
            SceneManager.LoadScene("Level");
        }
    }
    public void back() 
    {
        inputField.enabled = false;
        confirm.SetActive(false);
        first.enabled = false;
        first2.enabled = false;
        High.enabled = false;
        Back.SetActive(false);
        input.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }
    // Update is called once per frame
    void Update()
    {
        {
            first.text = fir;
            score = playerControl.save;
            first.text = fir;
            first2.text = score.ToString();
        }

    }
}
