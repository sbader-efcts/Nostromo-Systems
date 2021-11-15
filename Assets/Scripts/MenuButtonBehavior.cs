using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonBehavior : MonoBehaviour
{
    public Text Self;
    public Text Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Text.GetComponent<menuStartup>().Selection == Self)
        {
            Self.color = Color.yellow;
            Self.fontStyle = FontStyle.BoldAndItalic;
            
        }
        else
        {
            Self.color = Color.white;
            Self.fontStyle = FontStyle.Normal;
        }
    }
}
