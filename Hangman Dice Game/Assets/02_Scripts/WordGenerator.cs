using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator 
{

    private static string[] wordList = { "apple", "bread", "honey", "viola", "piano", "thorn" };

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }

}
