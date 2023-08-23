using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool _pauseFlug = false;
    AudioSource _audioRot;
    [SerializeField] AudioClip _openSE;
    [SerializeField] AudioClip _closeSE;
    void Start()
    {
        _audioRot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            PauseResume();
        }
    }

    void PauseResume()
    {
        _pauseFlug = !_pauseFlug;

        var objects = FindObjectsOfType<GameObject>();

        foreach (var obj in objects)
        {
            IPause i = obj.GetComponent<IPause>();
            if (_pauseFlug)
            {
                i?.Pause();
                _audioRot.PlayOneShot(_openSE);
            }
            else
            {
                i?.Resume();
                _audioRot.PlayOneShot(_closeSE);
            }
        }
    }
}
