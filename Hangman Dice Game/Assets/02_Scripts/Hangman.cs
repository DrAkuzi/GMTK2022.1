using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangman : MonoBehaviour
{
    List<GameObject> parts = new List<GameObject>();

    int currPart;

    public static Hangman instance;

    private void Awake()
    {
        instance = this;

        for(int i = 0; i < transform.childCount; i++)
        {
            parts.Add(transform.GetChild(i).gameObject);
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevealPart()
    {
        if (currPart >= GameManager.instance.GetMaxLife || currPart >= parts.Count)
            return;
        //print("here");
        parts[currPart].SetActive(true);
        currPart++;
    }
}
