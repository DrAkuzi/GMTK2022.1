using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    string str = "Books";
    public char[] wordAsChars;

    int currBlank;

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
        wordAsChars = word.word.ToCharArray(0, str.Length);
    }

    /// <summary>
    /// check subsequent letter is the same as current letter
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
    public bool ConsistDuplicateLetter(string letter)
    {
        for(int i = currBlank + 1; i < 5; i++)
        {
            if (wordAsChars[i].ToString() == letter)
                return true;
        }

        return false;
    }

    public bool CheckLetter(string letter)
    {
        if (letter != wordAsChars[currBlank].ToString())
        {
            Hangman.instance.RevealPart(Dice.instance.currRoll);
            return false;
        }

        Dice.instance.currRoll = 0;
        currBlank++;
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
