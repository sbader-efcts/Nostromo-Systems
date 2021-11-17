using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonBehavior : MonoBehaviour
{
    public Text Self;
    public Text Text;
    public AudioSource AudioSource;
    public AudioClip beep1;
    public AudioClip beep2;
    public AudioClip beep3;
    public AudioClip beep4;
    public static AudioClip beep;
    public static List<AudioClip> audioClips = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        audioClips.Add(beep1);
        audioClips.Add(beep2);
        audioClips.Add(beep3);
        audioClips.Add(beep4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Text.GetComponent<menuStartup>().Selection == Self)
        {
            beep = audioClips[Random.Range(0, 4)];
            Self.color = Color.yellow;
            Self.fontStyle = FontStyle.BoldAndItalic;
            AudioSource.clip = beep;
            AudioSource.Play();
        }
        else
        {
            Self.color = Color.white;
            Self.fontStyle = FontStyle.Normal;
        }
    }
}
