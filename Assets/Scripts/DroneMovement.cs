using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace DroneStuff
{
    public class DroneMovement : MonoBehaviour
    {
        public GameObject PauseMenu;
        public float speed;
        private Rigidbody2D rigid2d;
        private bool DoNotAllowMovement = false;
        private AudioSource audioSource;
        public GameObject FrontLightIndicator;
        public GameObject BackLightIndicator1;
        public GameObject BackLightIndicator2;

        void Start()
        {
            rigid2d = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();

            FrontLightIndicator.GetComponent<SpriteRenderer>().color = Color.gray;
            BackLightIndicator1.GetComponent<SpriteRenderer>().color = Color.gray;
            BackLightIndicator2.GetComponent<SpriteRenderer>().color = Color.gray;

            StartCoroutine(Blink());
        }

        public IEnumerator Blink()
        {
            FrontLightIndicator.GetComponent<SpriteRenderer>().color = Color.cyan;
            BackLightIndicator1.GetComponent<SpriteRenderer>().color = Color.red;
            BackLightIndicator2.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSecondsRealtime(1);
            FrontLightIndicator.GetComponent<SpriteRenderer>().color = Color.gray;
            BackLightIndicator1.GetComponent<SpriteRenderer>().color = Color.gray;
            BackLightIndicator2.GetComponent<SpriteRenderer>().color = Color.gray;
            yield return new WaitForSecondsRealtime(1);
            StartCoroutine(Blink());
        }

        void FixedUpdate()
        {
            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                if (DoNotAllowMovement == true)
                {
                    return;
                }
                else
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                        transform.Rotate(Vector3.forward * speed * 4);
                    }
                    else
                    {
                        transform.Rotate(Vector3.forward * speed * 4);
                    }
                }
            }
            else if (Input.GetKey("right") || Input.GetKey("d"))
            {
                if (DoNotAllowMovement == true)
                {
                    return;
                }
                else
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                        transform.Rotate(Vector3.forward * -1 * speed * 4);
                    }
                    else
                    {
                        transform.Rotate(Vector3.forward * -1 * speed * 4);
                    }
                }
            }
            else if (Input.GetKey("up") || Input.GetKey("w"))
            {
                if (DoNotAllowMovement == true)
                {
                    return;
                }
                else
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                        transform.Translate(Vector2.up * speed / 8);
                    }
                    else
                    {
                        transform.Translate(Vector2.up * speed / 8);
                    }
                }
            }
            else if (Input.GetKey("down") || Input.GetKey("s"))
            {
                if (DoNotAllowMovement == true)
                {
                    return;
                }
                else
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                        transform.Translate(Vector2.down * speed / 8);
                    }
                    else
                    {
                        transform.Translate(Vector2.down * speed / 8);
                    }
                }
            }
        }
        void Update()
        {
            if (Input.GetKeyUp("escape"))
            {
                if (PauseMenu.activeSelf)
                {
                    PauseMenu.SetActive(false);
                    DoNotAllowMovement = false;
                }
                else
                {
                    PauseMenu.SetActive(true);
                    DoNotAllowMovement = true;
                }
            }
        }
    }
}
