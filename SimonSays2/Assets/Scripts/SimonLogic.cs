using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimonLogic : MonoBehaviour
 {
    public AudioSource playaudio;
    public AudioSource gameoveraudio;

    public GameManager[] mybuttons;
    public List<int> colorList;

    public float showtime = 0.5f;
    public float pausetime = 0.5f;
    private int myrandom;
    public int level =2;
    private int playerLevel = 0;
    private bool simon = false;
    public bool player = false;

    public Button startbutton;
    public Button restart;
    public Text gameOver;
    public Text scoreText;
    private int score;



    void Start()
    {
        for (int i = 0; i < mybuttons.Length; i++)
        {
            mybuttons[i].onClick += ButtonClicked;
            mybuttons[i].myNumber = i;
        }


    }

    void ButtonClicked(int number)
    {
        playaudio.Play();

        if (player)
        {
            if(number == colorList[playerLevel])
            {
                playerLevel += 1;
                score += 1;
                scoreText.text = score.ToString();
                playaudio.Play();

            }
            else
            {
                Gameover();
            }
            if(playerLevel == level)
            {
                playaudio.Play();

                level += 1;
                playerLevel = 0;
                player = false;
                simon = true;
            }
        }
    }

    void Gameover()
    {
        gameoveraudio.Play();
        gameOver.text = "Game Over";
        startbutton.interactable = true;
        restart.onClick.AddListener(() => Restart1());


    }

    private void Update()
    {
        if (simon)
        {
            simon = false;
            StartCoroutine(Simon());

        }

    }
    public void StartGame()
    {

        simon = true;
        score = 0;
        playerLevel = 0;
        level = 2;
        scoreText.text = score.ToString();
        startbutton.interactable = false;


    }

    private IEnumerator Simon()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < level; i++)
        {
            if (colorList.Count < level)
            {
                myrandom = Random.Range(0, mybuttons.Length);
                colorList.Add(myrandom);
            }

            mybuttons[colorList[i]].ClickedColor();
            yield return new WaitForSeconds(showtime);
            mybuttons[colorList[i]].OffClickedColor();
            yield return new WaitForSeconds(pausetime);

        }
        player = true;
    }
    void Restart1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
