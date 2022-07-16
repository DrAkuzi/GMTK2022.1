using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {

    /*Dictionary<int, string> wordbook = new Dictionary<int, string>()
    {
        {0, "apple"},
        {1, "bread"},
        {2, "honey"},
        {3, "piano"},
        {4, "viola"},
        {5, "thorn"}
    };*/

    public string word;

    public Word(string _word)
    {
        word = _word;
    }

}
