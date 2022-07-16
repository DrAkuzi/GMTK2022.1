using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public List<Word> words;
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
            //tilesWord[i] = GameObject.Find(letter);

            tilesWord[i] = new GameObject();
            tilesWord[i].AddComponent<TextMeshProUGUI>().text = wordAsChars[i].ToString();

            //can create a list of gameobjects for the tiles & it will be assigned in order
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
