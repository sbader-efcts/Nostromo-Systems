using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuStartup : MonoBehaviour
{
    public Text myText;
    private bool startKeyCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroSequencePT1());
    }

    // Update is called once per frame
    void Update()
    {
        startKeyCheckfunc();
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
        myText.text += "\nPERFORMING STANDARD CHECKS...";
        yield return new WaitForSeconds(2);
        myText.text += ".";
        yield return new WaitForSeconds(2);
        myText.text += ".";
        yield return new WaitForSeconds(2);
        myText.text += ".";
        yield return new WaitForSeconds(2);
        myText.text += "\nDOUBLE CHECKING...";
        yield return new WaitForSeconds(1);
        myText.text += ".";
        yield return new WaitForSeconds(1);
        myText.text += ".";
        yield return new WaitForSeconds(1);
        myText.text += ".";
        yield return new WaitForSeconds(1);
        myText.text += "\nMANAGING PACKAGES...";
        yield return new WaitForSeconds(3);
        myText.text += ".";
        yield return new WaitForSeconds(2);
        myText.text += ".";
        yield return new WaitForSeconds(1);
        myText.text += ".";
        yield return new WaitForSeconds(1);
        myText.text += "\nLOGON:  ";
        myText.text += ".";
        yield return new WaitForSeconds(1);
        myText.text += ".";
        yield return new WaitForSeconds(1);
        myText.text += ".";
        yield return new WaitForSeconds(1);
        myText.text += ".";
        yield return new WaitForSeconds(1);
        myText.text += "\nCONFIRMED.";
        yield return new WaitForSeconds(2);
        myText.text += "\n\n____________________\n- NOSTROMO SYSTEMS -\n____________________\n\n     Welcome...\n                       ...PRESS ANY KEY TO ENTER...";
        startKeyCheck = true;
    }

    private void startKeyCheckfunc()
    {
        if(startKeyCheck == false)
        {
            return;
        }
        else
        {
            if (Input.anyKey)
            {

                SceneManager.LoadScene("Main");
                SceneManager.UnloadSceneAsync("TitleScreen");
            }
        }
    }
}
