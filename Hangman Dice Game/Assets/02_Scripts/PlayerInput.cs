using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    //ascii value
    int a = 97;
    int z = 122;
    int caps = 32;
    int aCaps = 65;
    int zCaps = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.GetGameState)
            GetKeyboardInput();
    }

    void GetKeyboardInput()
    {
        if (Input.anyKeyDown)
        {
            string input = Input.inputString;
            try
            {
                int ascii = Convert.ToInt32(input[0]);

                //we ignore numbers and anything inbetween zcaps and a ascii values
                if (ascii < aCaps || ascii > zCaps && ascii < a)
                    return;

                //convert to small if caps
                if (ascii < a)
                    ascii += caps;

                if (ascii > zCaps)
                    ascii -= caps;
                //print(ascii);
                //pass values here
                LetterManager.instance.LetterPressed(Convert.ToChar(ascii).ToString());
            }
            catch
            {
                //print("wrong");
            }
        }
    }
}
