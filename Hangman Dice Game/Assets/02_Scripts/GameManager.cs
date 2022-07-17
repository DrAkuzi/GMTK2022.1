using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    string str = "APPLE";
    public char[] wordAsChars;
    public Dictionary<int, string> wordList = new Dictionary<int, string>();

    public int blanksLeft { get { return wordList.Count; } }

    private void Awake()
    {
        instance = this;
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

        return count > 1;
    }

    public bool CheckLetter(string letter, out int pos)
    {
        pos = -1;
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
            //Dice.instance.currRoll = 0;
            return true;
        }
        else
        {
            Hangman.instance.RevealPart();
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
