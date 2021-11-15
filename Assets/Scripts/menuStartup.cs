using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuStartup : MonoBehaviour
{
    public Text myText;
    public Text Play;
    public Text Load;
    public Text Credits;
    public Text Exit;
    public Text Achievements;
    public Text Selection;
    List<Text> Buttons = new List<Text>();
    int SelectionIndex;
    bool isLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        Selection = Play;
        Buttons.Add(Play);
        Buttons.Add(Load);
        Buttons.Add(Credits);
        Buttons.Add(Exit);
        Buttons.Add(Achievements);
        SelectionIndex = Buttons.IndexOf(Selection);
        Play.gameObject.SetActive(false);
        Load.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        Achievements.gameObject.SetActive(false);
        StartCoroutine(IntroSequencePT1());
    }

    void Update()
    {
        if (isLoaded == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (SelectionIndex - 1 == -1)
                {
                    SelectionIndex = Buttons.Count - 1;
                }
                else
                {
                    SelectionIndex -= 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (SelectionIndex + 1 > Buttons.Count - 1)
                {
                    SelectionIndex = 0;
                }
                else
                {
                    SelectionIndex += 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                if (Selection == Buttons[0]) //play
                {
                    SceneManager.UnloadSceneAsync("TitleScreen");
                    SceneManager.LoadSceneAsync("Main");
                }
                else if (Selection == Buttons[1]) //load
                {

                }
                else if (Selection == Buttons[2]) //credits
                {

                }
                else if (Selection == Buttons[3]) //exit
                {
                    Application.Quit();
                }
                else if (Selection == Buttons[4]) //achievements
                {

                }
            }

            switch (SelectionIndex)
            {
                case 0:
                    Selection = Buttons[0];
                    break;
                case 1:
                    Selection = Buttons[1];
                    break;
                case 2:
                    Selection = Buttons[2];
                    break;
                case 3:
                    Selection = Buttons[3];
                    break;
                case 4:
                    Selection = Buttons[4];
                    break;
            }
        }
    }

    IEnumerator IntroSequencePT1()
    {
        yield return new WaitForSeconds(2);
        myText.text += ".";
        yield return new WaitForSeconds(2);
        myText.text += ".";
        yield return new WaitForSeconds(2);
        myText.text += ".";
        yield return new WaitForSeconds(2);
        Play.gameObject.SetActive(true);
        Load.gameObject.SetActive(true);
        Credits.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);
        Achievements.gameObject.SetActive(true);
        isLoaded = true;
    }
}
