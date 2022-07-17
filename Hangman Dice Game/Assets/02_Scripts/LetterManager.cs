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
    List<string> removedLetters = new List<string>();
    List<TextMeshProUGUI> currLetters = new List<TextMeshProUGUI>();

    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        SetLetters();
    }

    void SetLetters()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            string letter = System.Convert.ToChar(65 + i).ToString();
            letters[i].text = letter;
            Button b = letters[i].gameObject.AddComponent<Button>();
            ColorBlock colorVar = b.colors;
            colorVar.highlightedColor = new Color(0.3058f, 1f, 0.4392f);
            b.colors = colorVar;
            b.onClick.AddListener(delegate { LetterPressed(b); });

            currLetters.Add(letters[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLetters(int total)
    {
        for(int i = 0; i < total; i++)
        {
            int r = Random.Range(0, currLetters.Count);

            //if prev have been removed then find a new one
            if(!currLetters[r].GetComponent<Button>().interactable)
            {
                i--;
                continue;
            }

            //check for letters from word so we dnt remove them
            bool toRemove = true;
            for(int j = 0; j < blanks.Length; j++)
            {
                //print("check: " + GameManager.instance.wordAsChars[j].ToString() + ", " + currLetters[r].text);
                if (GameManager.instance.wordAsChars[j].ToString() == currLetters[r].text)
                {
                    //print("same");
                    toRemove = false;
                    break;
                }
            }

            if (toRemove)
            {
                //print("removing: " + currLetters[r].text);
                currLetters[r].GetComponent<Button>().interactable = false;
                removedLetters.Add(currLetters[r].text);
                currLetters.RemoveAt(r);
            }
            else
            {
                i--;
                //print("ignore");
            }
        }
    }

    public void ResetLetterState()
    {
        for(int i = 0; i < letters.Length; i++)
        {
            letters[i].GetComponent<Button>().interactable = true;
        }

        removedLetters.Clear();
        currLetters.Clear();

        for (int i = 0; i < letters.Length; i++)
            currLetters.Add(letters[i]);
    }

    //for button
    public void LetterPressed(Button b)
    {
        if (GameManager.instance.blanksLeft == 0 || !GameManager.instance.GetGameState)
            return;

        string letter = b.GetComponent<TextMeshProUGUI>().text;

        b.interactable = false;
        removedLetters.Add(letter);

        DisplayLetter(letter);
    }

    //for keyboard
    public void LetterPressed(string letter)
    {
        if (GameManager.instance.blanksLeft == 0 || removedLetters.Contains(letter))
            return;

        for (int i = 0; i < currLetters.Count; i++)
        {
            if (currLetters[i].text == letter)
            {
                //print("removing: " + currLetters[i].text);
                currLetters[i].GetComponent<Button>().interactable = false;
                removedLetters.Add(currLetters[i].text);
                break;
            }
        }

        DisplayLetter(letter);
    }

    void DisplayLetter(string letter)
    {
        int blankPos = 0;
        do
        {
            if (GameManager.instance.CheckLetter(letter, out blankPos))
            {
                blanks[blankPos].text = letter;
            }
        } while (GameManager.instance.ConsistDuplicateLetter(letter));
    }
}
