using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangman : MonoBehaviour
{
    List<GameObject> parts = new List<GameObject>();

    int total;
    int max;

    public static Hangman instance;

    private void Awake()
    {
        instance = this;

        for(int i = 0; i < transform.childCount; i++)
        {
            parts.Add(transform.GetChild(i).gameObject);
            transform.GetChild(i).gameObject.SetActive(false);
        }

        max = Random.Range(6, parts.Count + 1);
        //print("max parts: " + max);
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
        if (total >= max)
            return;

        parts[total].SetActive(true);
        total++;
    }
}
