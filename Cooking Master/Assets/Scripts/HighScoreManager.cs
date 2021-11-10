using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    //getter for instance
    private static HighScoreManager instance;
    //reference for instance of this class
    public static HighScoreManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<HighScoreManager>();
            return instance;
        }
    }
    //reference to container
    private Transform entryContainer;
    //reference to entry template
    private Transform entryTemplate;
    //reference for list of top scores
    private List<HighScore> topScoreList;
    //reference for list of transform entries
    private List<Transform> topScoreEntryTransformList;
    //Called before Start
    private void Awake()
    {
        //if we have the top scores key...
        if(!PlayerPrefs.HasKey("tScores"))
        {
            //initialize top score list
            topScoreList = new List<HighScore>();
            //create a zero score
            HighScore zero = new HighScore { score = 0 };
            //add the score to the list
            topScoreList.Add(zero);
            //intialize a new HighScoreList
            HighScoreList list = new HighScoreList { topScoreEntryList = topScoreList };
            //Save the list in PlayerPrefs
            PlayerPrefs.SetString("tScores", JsonUtility.ToJson(list));
        }
        //find the entry container
        entryContainer = transform.Find("HighScoreEntryList");
        //find the entry template
        entryTemplate = transform.Find("HighScoreEntryList/HighScoreEntry");
        //disable the one that's already there
        entryTemplate.gameObject.SetActive(false);

        //get the high score list from PlayerPrefs
        HighScoreList fromJson = JsonUtility.FromJson<HighScoreList>(PlayerPrefs.GetString("tScores"));

        //assign the top score list as the one from PlayerPrefs
        topScoreList = fromJson.topScoreEntryList;

        //for each of the entries in the list...
        for(int i = 0; i < topScoreList.Count; i++)
        {
            for(int j = i + 1; j < topScoreList.Count; j++)
            {
                //if score j is greater than score i...
                if(topScoreList[j].score > topScoreList[i].score)
                {
                    //...store the score at i
                    HighScore temp = topScoreList[i];
                    //assign score i to score j
                    topScoreList[i] = topScoreList[j];
                    //assign score j to the stored value
                    topScoreList[j] = temp;
                }
            }
        }
        //intialize top score entry transform list
        topScoreEntryTransformList = new List<Transform>();
        //for each value in the top score list...
        foreach(HighScore h in topScoreList)
        {
            //...create an entry in the UI
            CreateTopScoreUIEntry(h, entryContainer, topScoreEntryTransformList);
        }

    }
    public void AddTopScoreEntry(int scoreAmount)
    {
        //set up a new score based on the input parameter
        HighScore newScore = new HighScore { score = scoreAmount };

        //get the high score list from PlayerPrefs
        HighScoreList fromJson = JsonUtility.FromJson<HighScoreList>(PlayerPrefs.GetString("tScores"));

        //add the new score to the saved list
        fromJson.topScoreEntryList.Add(newScore);

        //save the list in PlayerPrefs
        PlayerPrefs.SetString("tScores", JsonUtility.ToJson(fromJson));
        //Save everything
        PlayerPrefs.Save();

    }    
    private void CreateTopScoreUIEntry(HighScore entry, Transform container, List<Transform> transformList)
    {
        //spawn a new entry transform object under the specified container
        Transform entryTransform = Instantiate(entryTemplate, container);
        //store the RectTransform component from the entry transform
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        //set the entry transform's anchored position
        entryRectTransform.anchoredPosition = new Vector2(0, -30f * transformList.Count);
        //enable the entry transform
        entryTransform.gameObject.SetActive(true);

        //set up the rank
        int rank = transformList.Count + 1;
        //local variable for the input score
        int score = entry.score;
        //set the rank text to that of the rank
        entryTransform.Find("Rank").GetComponent<Text>().text = rank.ToString();
        //set the score text to that of the score
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();
        //add the entry transform object to the transform list
        transformList.Add(entryTransform);
    }
}

public class HighScoreList
{
    //reference for the top score entry list that will be stored in PlayerPrefs
    public List<HighScore> topScoreEntryList;
}
[System.Serializable]
public class HighScore
{
    //reference for high scores
    public int score;
}
