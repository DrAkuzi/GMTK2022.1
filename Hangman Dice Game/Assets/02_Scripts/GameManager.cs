using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public List<Word> words;
    
    // Start is called before the first frame update
    void Start()
    {
       ChooseWord(); 
    }

    public void ChooseWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord());
        Debug.Log(word.word);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
