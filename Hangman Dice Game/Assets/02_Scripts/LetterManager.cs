using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterManager : MonoBehaviour
{
    public static LetterManager instance;

    [SerializeField] TextMeshProUGUI[] blanks;
    [SerializeField] TextMeshProUGUI[] letters;
    int currBlank;
    List<string> removedLetters = new List<string>();

    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        SetLetters();
        //RemoveLetters(Random.Range(1, 7));
    }

    void SetLetters()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].text = System.Convert.ToChar(65 + i).ToString();
            Button b = letters[i].gameObject.AddComponent<Button>();
            ColorBlock colorVar = b.colors;
            colorVar.highlightedColor = new Color(0.3058f, 1f, 0.4392f);
            b.colors = colorVar;
            b.onClick.AddListener(delegate { LetterPressed(b); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLetters(int total)
    {
        ResetLetterState();
        removedLetters.Clear();

        List<TextMeshProUGUI> temp = new List<TextMeshProUGUI>();

        for (int i = 0; i < letters.Length; i++)
            temp.Add(letters[i]);

        for(int i = 0; i < total; i++)
        {
            int r = Random.Range(0, temp.Count);
            temp[r].GetComponent<Button>().interactable = false;
            removedLetters.Add(temp[r].text);
            temp.RemoveAt(r);
        }
    }

    public void ResetLetterState()
    {

        for(int i = 0; i < letters.Length; i++)
        {
            letters[i].GetComponent<Button>().interactable = true;
        }
    }

    public void LetterPressed(Button b)
    {
        b.interactable = false;
        DisplayLetter(b.GetComponent<TextMeshProUGUI>().text);
    }

    public void DisplayLetter(string letter)
    {
        //print(letter);
        if (currBlank >= blanks.Length || removedLetters.Contains(letter))
            return;

        if (GameManager.instance.CheckLetter(letter))
        {
            blanks[currBlank].text = letter;
            currBlank++;
        }
        
        //RemoveLetters(Random.Range(1, 7));
    }
}
