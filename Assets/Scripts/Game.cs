using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //List of possible spawn (for token/player/AI)
    public GameObject[] spawnPoints;
    private int lastRandom = -1;

    //List of spawnable gameObjects
    public GameObject token;
    public GameObject chaser;
    public GameObject evader;
    public GameObject player;

    //Original Chaser Reference
    public AIAgent chaserRef;

    //Map Generation Reference
    public MapGenerator mapGen;

    //Token spawner timer
    private float tokenTimer = 30f;

    //CountDown variables
    [SerializeField] Text countDownText;
    [SerializeField] GameObject countDownUI;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayers();
        StartCountDown();

        //Get Original Chaser Reference
        chaserRef = GameObject.FindGameObjectWithTag("Chaser").GetComponent<AIAgent>();

        //Get Map Generation Reference
        mapGen = GameObject.FindGameObjectWithTag("Map").GetComponent<MapGenerator>();

        //Spawn Tokens periodically
        InvokeRepeating("SpawnToken", 5.0f, tokenTimer);
    }

    public void SpawnToken()
    {
        //Spawn a token on a random node
        int node = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = new Vector3 (spawnPoints[node].transform.position.x, 1.5f, spawnPoints[node].transform.position.z);
        Instantiate(token, spawnPosition, Quaternion.AngleAxis(-90, Vector3.right));

        if (!chaserRef.isGoingForToken)
            //Give the original chaser the node where the token spawned
            chaserRef.goalNode = mapGen.Map.graphNodes[node];
    }

    public void SpawnPlayers()
    {
        //Spawn Player
        int node = GetRandom();
        player.transform.position = spawnPoints[node].transform.position;

        //Spawn Chaser
        node = GetRandom();
        chaser.transform.position =  spawnPoints[node].transform.position;

        //Spawn Evaders
        for (int i=0; i<10; i++)
        {
            node = GetRandom();
            Instantiate(evader, spawnPoints[node].transform.position, Quaternion.identity);
        }
    }

    //Make a 3,2,1.. go countdown before the game starts
    public void StartCountDown()
    {
        countDownUI.SetActive(true);
        StartCoroutine(Countdown(4));
    }

    IEnumerator Countdown(int seconds)
    {
        Time.timeScale = 0;

        while (seconds > 0)
        {
            if (seconds == 1)
            {
                countDownText.text = "GO!!";
            }
            else
            {
                //Show countdown
                countDownText.text = "GAME STARTING..." + (seconds - 1).ToString();
            }

            yield return new WaitForSecondsRealtime(1);
            seconds--;
        }

        countDownUI.SetActive(false);
        Time.timeScale = 1;
    }

    public int GetRandom()
    {
        int rand = Random.Range(0, spawnPoints.Length);

        //Ensure the last random value is different from the new one
        while (rand == lastRandom)
            rand = Random.Range(0, spawnPoints.Length);

        lastRandom = rand;
        return rand;
    }
}
