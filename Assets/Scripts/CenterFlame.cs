using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFlame : MonoBehaviour
{
    private AudioSource _audioSource;
    private TimingManager _timingManager;
    bool musicStart = false;

    private void Start()
    {
        _timingManager = FindObjectOfType<TimingManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart && collision.CompareTag("Note"))
        {
            _timingManager.CheckTiming();
            _audioSource.Play();
            musicStart = true;
        }
    }
}
