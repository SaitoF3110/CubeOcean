using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIManager : MonoBehaviour,IPause
{
    // Start is called before the first frame update
    [SerializeField] bool _onPauseObj = true;
    void Start()
    {
        if (_onPauseObj)
            transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        if (_onPauseObj)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(0, 0, 0);
    }
    public void Resume()
    {
        if (_onPauseObj)
            transform.localScale = new Vector3(0, 0, 0);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }
}
