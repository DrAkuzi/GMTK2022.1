using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangman : MonoBehaviour
{
    List<GameObject> partsList = new List<GameObject>();

    int currPart;

    public static Hangman instance;

    [SerializeField] Transform parts; 
    [SerializeField] Transform props; 

    public int GetPartsCount { get { return partsList.Count; } }

    AudioSource audio;

    private void Awake()
    {
        instance = this;
        audio = GetComponent<AudioSource>();

        //head spine arms face prop1 prop2 left leg right leg


        for (int i = 0; i < 4; i++)
        {
            partsList.Add(parts.GetChild(i).gameObject);
            parts.GetChild(i).gameObject.SetActive(false);
        }

        int rng = -1;
        for (int i = 0; i < 2; i++)
        {
            int num = Random.Range(0, props.childCount);

            //make sure its diff number
            if(num == rng)
            {
                i--;
            }
            else
            {
                partsList.Add(props.GetChild(num).gameObject);
                rng = num;
            }
        }

        for (int i = 4; i < parts.childCount; i++)
        {
            partsList.Add(parts.GetChild(i).gameObject);
            parts.GetChild(i).gameObject.SetActive(false);
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
        if (currPart >= GameManager.instance.GetMaxLife || currPart >= partsList.Count)
            return;
        audio.PlayOneShot(audio.clip);
        //print("here");
        partsList[currPart].SetActive(true);
        currPart++;
    }
}
