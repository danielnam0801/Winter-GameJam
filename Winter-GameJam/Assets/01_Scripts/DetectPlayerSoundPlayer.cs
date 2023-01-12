using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerSoundPlayer : MonoBehaviour
{
    public float canHearSoundRadius = 3f;
    [SerializeField] AudioSource audioSource;   

    CircleCollider2D checkSoundCollider;

    public bool soundPlaying = false;

    private Transform target;
    private float distanceToTarget = 0f;
    private float maxDistance;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        target = GameObject.Find("Player").transform;
        checkSoundCollider = GetComponent<CircleCollider2D>();
        maxDistance = checkSoundCollider.radius/2;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(audioSource != null)
            {
                if (!soundPlaying)
                {
                    soundPlaying = true;
                    audioSource.Play();
                }
                else
                {
                    SoundControll();
                }

            }
        }
    }

    private void SoundControll()
    {
        float soundValue = Vector3.Distance(target.position, transform.position);
        audioSource.volume = 1/(soundValue / maxDistance);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soundPlaying = false;
        }
    }

}
