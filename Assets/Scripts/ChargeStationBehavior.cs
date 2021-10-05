using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneStuff
{
    public class ChargeStationBehavior : MonoBehaviour
    {
        public GameObject DroneObject;
        public Collider2D DroneCollider;
        public Collider2D SelfCollider;
        public AudioSource ChargingSound;
        public AudioSource BeepSound;
        public GameObject ChargeIcon;
        public GameObject Battery1;
        public GameObject Battery2;

        void Start()
        {
            ChargeIcon.SetActive(false);
        }

        void Update()
        {
            if (SelfCollider.IsTouching(DroneCollider) && (Input.GetKeyUp("e") || Input.GetKeyUp(KeyCode.RightControl)) && DroneObject.GetComponent<DroneMovement>().DoNotAllowMovement == false)
            {
                BeepSound.Play();
                DroneObject.GetComponent<DroneMovement>().BlinkOverride = true;
                DroneObject.GetComponent<DroneMovement>().FrontLightIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
                DroneObject.GetComponent<DroneMovement>().BackLightIndicator1.GetComponent<SpriteRenderer>().color = Color.yellow;
                DroneObject.GetComponent<DroneMovement>().BackLightIndicator2.GetComponent<SpriteRenderer>().color = Color.yellow;
                StartCoroutine(ChargeStationShow());
            }
        }

        IEnumerator ChargeStationShow()
        {
            BatteryBehavior Battery1Behavior = Battery1.GetComponent<BatteryBehavior>();
            BatteryBehavior Battery2Behavior = Battery2.GetComponent<BatteryBehavior>();
            int currentLevel1 = Battery1Behavior.BatteryLevel;
            int currentLevel2 = Battery2Behavior.BatteryLevel;

            DroneObject.GetComponent<DroneMovement>().DoNotAllowMovement = true;
            ChargingSound.loop = true;
            ChargingSound.Play();
            ChargeIcon.SetActive(true);
            Debug.Log("shown");
            Battery1Behavior.StopCoroutine("BatteryDecay");
            Battery2Behavior.StopCoroutine("BatteryDecay");
            Battery1Behavior.BatteryDecayOverride = true;
            Battery2Behavior.BatteryDecayOverride = true;
            while (currentLevel1 < 5 || currentLevel2 < 5)
            {
                Battery1.GetComponent<SpriteRenderer>().color = Color.white;
                Battery2.GetComponent<SpriteRenderer>().color = Color.white;
                yield return new WaitForSecondsRealtime(1);
                Battery1Behavior.BatteryLevel += 1;
                Battery2Behavior.BatteryLevel += 1;
                Battery1.GetComponent<SpriteRenderer>().sprite = Battery1Behavior.Sprites[Battery1Behavior.BatteryLevel - 1];
                Battery2.GetComponent<SpriteRenderer>().sprite = Battery1Behavior.Sprites[Battery2Behavior.BatteryLevel - 1];
                currentLevel1 = Battery1Behavior.BatteryLevel;
                currentLevel2 = Battery2Behavior.BatteryLevel;
            }
            Debug.Log("charged");
            ChargingSound.Stop();
            ChargeIcon.SetActive(false);
            Debug.Log("hidden");
            BeepSound.Play();
            DroneObject.GetComponent<DroneMovement>().BlinkOverride = false;
            StartCoroutine(DroneObject.GetComponent<DroneMovement>().Blink());
            DroneObject.GetComponent<DroneMovement>().DoNotAllowMovement = false;
            Battery1.GetComponent<SpriteRenderer>().color = Color.white;
            Battery2.GetComponent<SpriteRenderer>().color = Color.white;
            Battery1Behavior.BatteryDecayOverride = false;
            Battery2Behavior.BatteryDecayOverride = false;
            Battery1Behavior.StartCoroutine("BatteryDecay");
            Battery2Behavior.StartCoroutine("BatteryDecay");
        }
    }
}
