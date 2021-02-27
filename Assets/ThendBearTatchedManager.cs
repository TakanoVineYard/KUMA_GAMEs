using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ThendBearTatchedManager : MonoBehaviour
{

    public Animator clickedReActionAnimator;

    public GameObject clickedGameObject;

    public AudioSource kmgms_TouchedAudioSource;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
                kmgms_TouchedAudioSource.Play();
                PlayEmo();
            }

            Debug.Log(clickedGameObject);
        }
    }

    void PlayEmo()
    {
        clickedReActionAnimator.CrossFadeInFixedTime("Emo" + ((UnityEngine.Random.Range(0, 19).ToString().PadLeft(2, '0'))), 0.01f);

    }
}
