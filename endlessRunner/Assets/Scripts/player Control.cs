using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class playerControl : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public float JumpSpeed = 15.0f;
    public float Gravity = -9.8f;
    private float YSpeed = -20f;
    public static int checker = 0;
    public static int Magnet = 0;
    public static int numberOfCoins;
    public Text containCoins;
    public TextMeshProUGUI Lose;
    public GameObject platagainbutton;
    public GameObject panel;
    public static int save;

    CharacterController CharController;
    Animator animator;

    private void Awake()
    {
        numberOfCoins = 0;

        Time.timeScale = 1f;
    }
    void Start()
    {
        CharController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        panel.SetActive(false);
        Lose.enabled = false;
        platagainbutton.SetActive(false);
        Gamecontrol.QuitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float Move_X = Input.GetAxis("Horizontal");
        float Move_Z = MoveSpeed;
        Vector3 Movement = new Vector3(Move_X * MoveSpeed, 0, Move_Z);
        Movement = Vector3.ClampMagnitude(Movement, 1.0f);
        if (CharController.isGrounded)
        {
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
            {
                YSpeed = JumpSpeed;
                animator.SetTrigger("Jump");
            }
            

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Slide());
        }
        else
        {
            YSpeed += Gravity * 5 * Time.deltaTime;
        }
        Movement *= MoveSpeed;
        Movement.y = YSpeed;
        Movement *= Time.deltaTime;
        CharController.Move(Movement);

        containCoins.text = "Coins:" + playerControl.numberOfCoins;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Time.timeScale = 0f;
            Lose.enabled = true;
            platagainbutton.SetActive(true);
            panel.SetActive(true);
            Gamecontrol.QuitButton.SetActive(true);
            save = numberOfCoins;

        }
        if (other.CompareTag("Jump"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Hjump());

        }
        if (other.CompareTag("Score"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Dscore());

        }



    }

    public void playagin()
    {
        Debug.Log("click");
        SceneManager.LoadScene("Level");
    }
    private IEnumerator Slide()
    {
        animator.SetTrigger("Slide");
        CharController.center = new Vector3(0, 0.5f, 0);
        CharController.height = 1;
        yield return new WaitForSeconds(1f);
        CharController.center = new Vector3(0, 1f, 0);
        CharController.height = 2;

    }
    private IEnumerator Hjump() 
    {
        JumpSpeed = 25f;
        YSpeed = -35f;
        yield return new WaitForSeconds(15f);
        JumpSpeed = 15f;
        YSpeed = -20f;


    }
    private IEnumerator Dscore()
    {
        checker = 1;
       yield return new WaitForSeconds(15f);
        checker = 0;



    }

}

