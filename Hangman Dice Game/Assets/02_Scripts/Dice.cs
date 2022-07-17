using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dice : MonoBehaviour
{
    public static Dice instance;

    //array of dice sides sprites
    public Sprite[] diceSides;
    [SerializeField] TextMeshProUGUI text;

    //ref to sprite renderer to change sprites
    //SpriteRenderer sr;
    Image image;

    bool isRolling;

    public int maxRoll = 3;
    public int currRoll;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();

        //diceSides = 01_Sprites.LoadAll<Sprite>("Placeholder/");        
    }

    public void Roll()
    {
        if (!GameManager.instance.GetGameState)
            return;

        if (!isRolling && currRoll < maxRoll)
        {
            text.text = "";
            StartCoroutine("RollDice");
            isRolling = true;

            if (currRoll > 0)
            {
                Hangman.instance.RevealPart();
            }
        }
    }

    private IEnumerator RollDice()
    {
        //variable to contain random dice side number while rolling. needs to be assigned so let it be 0 initially
        int randomDiceSide = 0;

        //dice roll result
        int newDiceNumber = 0;

        //switching dice sides randomly for roll animation before result appears
        for (int i = 0; i <= 20; i++)
        {
            //pick random value of dice
            randomDiceSide = Random.Range(0, 6);

            //set sprite to the corresponding dice face according to its value
            image.sprite = diceSides[randomDiceSide];

            //duration where each side is showing
            yield return new WaitForSeconds(0.1f);
        }
        if (currRoll < 1)
        {
            randomDiceSide = Random.Range(2, 6);
            image.sprite = diceSides[randomDiceSide];
            //Debug.Log("player advantage");
        }
        newDiceNumber = randomDiceSide + 1;
        isRolling = false;
        currRoll++;
        ChangeText();
        LetterManager.instance.RemoveLetters(newDiceNumber);
        //Debug.Log("dice rolled " + newDiceNumber);
        //Debug.Log("current roll count is: " + currRoll);
    }

    void ChangeText()
    {
        string tex = "";
        switch(currRoll)
        {
            case 1:
            case 2:
                tex = "Pay with life for another roll";
                break;

            case 3:
                tex = "Roll limit reached :(";
                break;

        }

        text.text = tex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
