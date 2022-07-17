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
    int maxLife;
    public int GetMaxLife { get { return maxLife; } }

    bool gameIsActive = true;
    public bool GetGameState { get { return gameIsActive; } }

    int wordsGuessed;
    int lettersGuessed;
    int totalRolls;
    int currStreak;
    int longestStreak;
    public int MainMenuIndex;

    [SerializeField] GameObject ResultPage;
    [SerializeField] GameObject[] ResultTexts;
    [SerializeField] GameObject[] ToHide;

    private void Awake()
    {
        instance = this;

        wordsGuessed = PlayerPrefs.GetInt("words");
        lettersGuessed = PlayerPrefs.GetInt("letters");
        totalRolls = PlayerPrefs.GetInt("rolls");
        currStreak = PlayerPrefs.GetInt("current_streak");
        longestStreak = PlayerPrefs.GetInt("longest_streak");

        ChooseWord();
    }

    // Start is called before the first frame update
    void Start()
    {
        maxLife = Hangman.instance.GetPartsCount;
        currLife = maxLife;
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
        longestStreak++;
        PlayerPrefs.SetInt("longest_streak", longestStreak);
        currStreak++;
        PlayerPrefs.SetInt("current_streak", currStreak);
        gameIsActive = false;
        ResultTexts[0].SetActive(true);
        for (int i = 0; i < ToHide.Length; i++)
            ToHide[i].SetActive(false);
    }

    void Lose()
    {
        ResultPage.SetActive(true);
        PlayerPrefs.SetInt("letters", lettersGuessed);
        totalRolls += Dice.instance.currRoll;
        PlayerPrefs.SetInt("rolls", totalRolls);
        currStreak = 0;
        PlayerPrefs.SetInt("current_streak", currStreak);
        gameIsActive = false;
        ResultTexts[1].SetActive(true);
        for (int i = 0; i < ToHide.Length; i++)
            ToHide[i].SetActive(false);
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
