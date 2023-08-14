using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool _pauseFlug = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
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
            }
            else
            {
                i?.Resume();
            }
        }
    }
}
