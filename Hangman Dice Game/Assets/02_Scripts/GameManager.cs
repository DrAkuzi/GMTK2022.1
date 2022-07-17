using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    string str = "APPLE";
    public char[] wordAsChars;
    public Dictionary<int, string> wordList = new Dictionary<int, string>();

    public int blanksLeft { get { return wordList.Count; } }

    int currLife;
    int maxLife = 10;
    public int GetMaxLife { get { return maxLife; } }

    bool gameIsActive = true;
    public bool GetGameState { get { return gameIsActive; } }

    int wordsGuessed;
    int lettersGuessed;
    int totalRolls;
    public int MainMenuIndex;

    [SerializeField] GameObject ResultPage;
    [SerializeField] TextMeshProUGUI[] Stats;
    [SerializeField] GameObject[] ResultTexts;

    private void Awake()
    {
        instance = this;

        currLife = maxLife;

        wordsGuessed = PlayerPrefs.GetInt("words");
        lettersGuessed = PlayerPrefs.GetInt("letters");
        totalRolls = PlayerPrefs.GetInt("rolls");

        ChooseWord();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void ChooseWord() //generates a word randomly from list
    {
        Word word = new Word(WordGenerator.GetRandomWord());
        Debug.Log(word.word);
        //convert word string into an array of separate characters
        wordAsChars = word.word.ToCharArray(0, word.word.Length);
        for(int i = 0; i < word.word.Length; i++)
        {
            wordList.Add(i, wordAsChars[i].ToString());
        }
    }

    /// <summary>
    /// check subsequent letter is the same as current letter
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
    public bool ConsistDuplicateLetter(string letter)
    {
        int count = 0;

        foreach (var key in wordList.Keys)
        {
            if (wordList[key] == letter)
            {
                count++;
            }
        }

        return count > 0;
    }

    public bool CheckLetter(string letter, out int pos)
    {
        //print("check");
        pos = -1;
        lettersGuessed++;
        foreach (var key in wordList.Keys)
        {
            if(wordList[key] == letter)
            {
                pos = key;
            }
        }

        if (pos >= 0)
        {
            wordList.Remove(pos);
            
            if(wordList.Count == 0)
                Win();

            return true;
        }
        else
        {
            //print("wrong");
            Hangman.instance.RevealPart();
            currLife--;

            if (currLife <= 0)
                Lose();

            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Win()
    {
        ResultPage.SetActive(true);
        wordsGuessed++;
        PlayerPrefs.SetInt("words", wordsGuessed);
        PlayerPrefs.SetInt("letters", lettersGuessed);
        totalRolls += Dice.instance.currRoll;
        PlayerPrefs.SetInt("rolls", totalRolls);
        gameIsActive = false;
        UpdateStatsText();
        ResultTexts[0].SetActive(true);
    }

    void Lose()
    {
        ResultPage.SetActive(true);
        PlayerPrefs.SetInt("letters", lettersGuessed);
        totalRolls += Dice.instance.currRoll;
        PlayerPrefs.SetInt("rolls", totalRolls);
        gameIsActive = false;
        UpdateStatsText();
        ResultTexts[1].SetActive(true);
    }

    void UpdateStatsText()
    {
        Stats[0].text = "Words guessed: " + PlayerPrefs.GetInt("words").ToString();
        Stats[1].text = "Letters guessed: " + PlayerPrefs.GetInt("letters").ToString();
        Stats[2].text = "No. of rolls: " + PlayerPrefs.GetInt("rolls").ToString();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(MainMenuIndex);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
