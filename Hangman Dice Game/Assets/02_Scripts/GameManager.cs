using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public List<Word> words;
    //private GameObject[] tilesAll;
    //Object[] with only word tiles
    public GameObject[] tilesWord;
    string str = "Books";
    public char[] wordAsChars;
    
    // Start is called before the first frame update
    void Start()
    {
       ChooseWord();
    }

    public void ChooseWord() //generates a word randomly from list
    {
        Word word = new Word(WordGenerator.GetRandomWord());
        Debug.Log(word.word);
        SetTiles(word.word);
    }

    public void SetTiles(string selectedWord)
    {
        //populating letter tiles into the tiles array
        //tilesAll = new GameObject[] {A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z};

        Debug.Log("selected word is " + selectedWord);
        //convert word string into an array of separate characters
        wordAsChars = selectedWord.ToCharArray(0, str.Length);
        //create space for the array 
        tilesWord = new GameObject[selectedWord.Length];
        //populating only word's letter tiles into this array
        for(int i=0; i<wordAsChars.Length; i++)
        {
            //each letter is converted to a string so it can be used in GameObject.Find
            string letter = "" + wordAsChars[i];
            //find the gameobject that is of the same letter
            tilesWord[i] = GameObject.Find(letter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
