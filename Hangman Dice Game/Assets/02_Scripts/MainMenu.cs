using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public int gameScene;

    //menu - 0, settings - 1, stats - 2
    [SerializeField] GameObject[] Pages;
    [SerializeField] TextMeshProUGUI[] Stats;

    int currPage;

    // Start is called before the first frame update
    void Start()
    {
        Stats[0].text = "Words guessed: " + PlayerPrefs.GetInt("words").ToString();
        Stats[1].text = "Letters guessed: " + PlayerPrefs.GetInt("letters").ToString();
        Stats[2].text = "No. of rolls: " + PlayerPrefs.GetInt("rolls").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPage(int page)
    {
        Pages[currPage].SetActive(false);
        currPage = page;
        Pages[currPage].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
