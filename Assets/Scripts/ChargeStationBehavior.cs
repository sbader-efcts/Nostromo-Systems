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

        void Start()
        {
            ChargeIcon.SetActive(false);
        }

        void Update()
        {
            if (SelfCollider.IsTouching(DroneCollider) && Input.GetKey("e") && DroneObject.GetComponent<DroneMovement>().DoNotAllowMovement == false)
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
            DroneObject.GetComponent<DroneMovement>().DoNotAllowMovement = true;
            ChargingSound.loop = true;
            ChargingSound.Play();
            ChargeIcon.SetActive(true);
            Debug.Log("shown");
            yield return new WaitForSecondsRealtime(5);
            ChargingSound.Stop();
            ChargeIcon.SetActive(false);
            Debug.Log("hidden");
            DroneObject.GetComponent<DroneMovement>().BlinkOverride = false;
            StartCoroutine(DroneObject.GetComponent<DroneMovement>().Blink());
            DroneObject.GetComponent<DroneMovement>().DoNotAllowMovement = false;
        }
    }
}
