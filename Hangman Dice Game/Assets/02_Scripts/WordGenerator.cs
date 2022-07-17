using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator 
{

    private static string[] wordList = { "APPLE", "ADORE", "ABYSS", "AROMA", "ARMOR", "BEACH", "BEIGE", "BREAD", "BACON", "CREAM", "CREPE", "CHANT", "CHART",
    "CHAIR", "COAST", "COCOA", "DAIRY", "DANCE", "DENIM", "DEMON", "DEVIL", "DIARY", "DINER", "DISCO", "DREAM", "DRAKE", "DRAFT", "ELDER", "ELBOW", 
    "EMAIL", "FAIRY", "FAUNA", "FONDU", "FROST", "FLOOD", "FLOOR", "FLORA", "FENCE", "FLEET",
    "GRAPE", "GNOME", "GOLEM", "HONEY", "IGLOO", "ICING", "INBOX", "JOKER", "JUICE", "KHAKI", "KOALA", "LEMON", "LILAC", "LIGHT", "LOTUS", "MANGO",
    "MODEL", "NORTH", "NYMPH", "OASIS", "OLIVE", "OPERA", "OTTER", "PEONY", "PIANO", "QUEEN", "QUOTE", "RADAR", "RAVEN", "ROBIN", "SNAKE", "SOUTH",
    "STONE", "THORN", "UNION", "VIOLA", "WOUND", "YACHT", "ZEBRA" };

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }

}
