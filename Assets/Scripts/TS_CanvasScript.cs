using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TS_CanvasScript : MonoBehaviour
{
    public GameObject Cursor_Object;
    public float BlinkInterval;
    private AudioSource audioSource;

    void Start()
    {
        SceneManager.UnloadSceneAsync("Main");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TitleScreen"));
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        InvokeRepeating("BlinkingCursor", 1, BlinkInterval);
    }

    public void BlinkingCursor()
    { 
        if (Cursor_Object.activeSelf == true)
        {
            Cursor_Object.SetActive(false);
        }
        else
        {
            Cursor_Object.SetActive(true);
        }
    }
}
