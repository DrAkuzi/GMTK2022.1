using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public static Dice instance;

    //array of dice sides sprites
    public Sprite[] diceSides;

    //ref to sprite renderer to change sprites
    SpriteRenderer sr;

    bool isRolling;

    public int maxRoll = 3;
    public int currRoll;
    int totalRolls;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        //diceSides = 01_Sprites.LoadAll<Sprite>("Placeholder/");        
    }

    private void OnMouseDown()
    {
        if (!isRolling && currRoll <= maxRoll)
        {   
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
            sr.sprite = diceSides[randomDiceSide];

            //duration where each side is showing
            yield return new WaitForSeconds(0.1f);
        }
        if (currRoll < 1)
        {
            randomDiceSide = Random.Range(2, 6);
            sr.sprite = diceSides[randomDiceSide];
            Debug.Log("player advantage");
        }
        newDiceNumber = randomDiceSide + 1;
        isRolling = false;
        currRoll++;
        totalRolls++;
        LetterManager.instance.RemoveLetters(newDiceNumber);
        Debug.Log("dice rolled " + newDiceNumber);
        Debug.Log("current roll count is: " + currRoll);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
