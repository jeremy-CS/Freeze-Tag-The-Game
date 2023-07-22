using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChanges : MonoBehaviour
{
    //Timer variables
    public float timeRemaining = 300f;
    private string minutes;
    private string seconds;
    private bool timerIsRunning = false;
    private bool timerDone = false;

    //Player/Original Chaser variables
    public Player playerRef;
    public AIAgent chaserRef;

    //Counter variables
    public static int evaderCounter = 0;
    public static int chaserCounter = 0;

    //UI variables
    public Text timerText;
    public Text playerTokenText;
    public Text chaserTokenText;
    public Text evaderCounterText;
    public Text chaserCounterText;

    //Game Over UI
    public GameObject gameOverUI;
    public Text winnerText;

    private void Awake()
    {
        evaderCounter = 0;
        chaserCounter = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        chaserRef = GameObject.FindGameObjectWithTag("Chaser").GetComponent<AIAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            //Update timer
            UpdateTimer();

            //Update Tokens
            UpdateTokens();

            //Update role counters
            UpdateCounters();
        }

        if (timerDone)
        {
            //End game
            EndGame(false);
        }
    }

    //Update timer on-screen
    public void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            minutes = Mathf.FloorToInt(timeRemaining / 60).ToString();
            seconds = Mathf.FloorToInt(timeRemaining % 60).ToString("00");
        }
        else
        {
            Debug.Log("Timer has run out");
            timeRemaining = 0;
            minutes = "0";
            seconds = "00";
            timerIsRunning = false;
            timerDone = true;
        }
        //Update Timer text
        timerText.text = minutes + "." + seconds;
    }

    //Update token counters
    public void UpdateTokens()
    {
        if (playerRef != null)
            playerTokenText.text = "player: " + playerRef.tokenCounter + " / 10 tokens";

        if (chaserRef != null)
            chaserTokenText.text = "chaser: " + chaserRef.tokenCounter + " / 10 tokens";
    }

    //Update chasers/evaders counters
    public void UpdateCounters()
    {
        evaderCounterText.text = evaderCounter + " x evaders";
        chaserCounterText.text = chaserCounter + " x chasers";
    }

    //End Game
    public void EndGame(bool playerFrozen)
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);

        //Display the winner's side
        if (playerRef.tokenCounter > chaserRef.tokenCounter && !playerFrozen)
        {
            winnerText.text = "evaders win!!";
        }
        else
        {
            winnerText.text = "chasers win...";
        }
    }
}
