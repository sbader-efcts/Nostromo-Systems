using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneStuff
{
    public class BatteryBehavior : MonoBehaviour
    {
        public GameObject Self;
        public Sprite Five;
        public Sprite Four;
        public Sprite Three;
        public Sprite Two;
        public Sprite One;
        public int BatteryLevel;
        public float BatteryDrainRate;
        public List<Sprite> Sprites;
        public bool BatteryDecayOverride = false;

        void Start()
        {
            Sprites.Add(One);
            Sprites.Add(Two);
            Sprites.Add(Three);
            Sprites.Add(Four);
            Sprites.Add(Five);
            StartCoroutine(BatteryDecay());
        }

        public IEnumerator BatteryDecay()
        {
            yield return new WaitForSecondsRealtime(BatteryDrainRate);
            if (BatteryDecayOverride == false)
            {
                switch (BatteryLevel)
                {
                    case 5:
                        BatteryLevel -= 1;
                        Self.GetComponent<SpriteRenderer>().sprite = Sprites[3];
                        Self.GetComponent<SpriteRenderer>().color = Color.white;
                        StartCoroutine("BatteryDecay");
                        break;
                    case 4:
                        BatteryLevel -= 1;
                        Self.GetComponent<SpriteRenderer>().sprite = Sprites[2];
                        Self.GetComponent<SpriteRenderer>().color = Color.white;
                        StartCoroutine("BatteryDecay");
                        break;
                    case 3:
                        BatteryLevel -= 1;
                        Self.GetComponent<SpriteRenderer>().sprite = Sprites[1];
                        Self.GetComponent<SpriteRenderer>().color = Color.white;
                        StartCoroutine("BatteryDecay");
                        break;
                    case 2:
                        BatteryLevel -= 1;
                        Self.GetComponent<SpriteRenderer>().sprite = Sprites[0];
                        Self.GetComponent<SpriteRenderer>().color = Color.white;
                        StartCoroutine("BatteryDecay");
                        break;
                    case 1:
                        BatteryLevel -= 1;
                        Self.GetComponent<SpriteRenderer>().sprite = Sprites[4];
                        Self.GetComponent<SpriteRenderer>().color = Color.red;
                        StartCoroutine("BatteryDecay");
                        break;
                }
                Debug.Log("Battery Level is: " + BatteryLevel);
            }
            else if (BatteryDecayOverride == true)
            {
                Debug.Log("Battery Level is: " + BatteryLevel);
                Self.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
