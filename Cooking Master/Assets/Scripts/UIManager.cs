using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //reference for blue player time UI
    public Text bluePlayerTimeText;
    //reference for blue player score UI
    public Text bluePlayerScoreText;
    //reference for red player time UI
    public Text redPlayerTimeText;
    //reference for red player score UI
    public Text redPlayerScoreText;

    //reference for endgame UI
    public GameObject endUI;

    //reference for instance getter
    private static UIManager instance;

    //instance for this class
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdatePlayerScore(int newScore, bool bluePlayer)
    {
        //if we're the blue player...
        if(bluePlayer)
        {
            //...set the text of the blue player score to say Score: newScore
            if(bluePlayerScoreText != null)
            {
                bluePlayerScoreText.text = string.Format("Score: {0}", newScore.ToString());
            }
        }
        //otherwise...
        else
        {
            //...set the text of the red player score to say Score: newScore
            if(redPlayerScoreText != null)
            {
                redPlayerScoreText.text = string.Format("Score: {0}", newScore.ToString());
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
