using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamecontrol : MonoBehaviour
{
    public TextMeshProUGUI Pause;
    public GameObject Resume;
    public static GameObject QuitButton;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        QuitButton = GameObject.Find("Quit");
        Pause.enabled = false;
        Resume.SetActive(false);
        panel.SetActive(false);
        QuitButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) 
        {
            Time.timeScale = 0f;
            QuitButton.SetActive(true);
            Pause.enabled = true;
            Resume.SetActive(true);
            panel.SetActive(true);


        }
    }
   public  void Reset()
    {
        Time.timeScale = 1f;
        Pause.enabled = false;
        Resume.SetActive(false);
        panel.SetActive(false);
        QuitButton.SetActive(false);


    }
    public void Quit() 
    {
        SceneManager.LoadScene("Main Menu");
    }
}
