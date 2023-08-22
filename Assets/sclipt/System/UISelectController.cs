using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectController : MonoBehaviour, IPause
{
    // Start is called before the first frame update
    [SerializeField] Transform[] transforms;
    AudioSource _audio;
    int _amount;//‘I‘ğˆ‚Ì”
    int _nowSelect;
    bool _active;
    void Start()
    {
        _amount = transforms.Length - 1;
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _nowSelect += GetAmount();
        CountFix();
        this.transform.position = transforms[_nowSelect].position;
    }
    void CountFix()
    {
        if(_nowSelect > _amount)
        {
            _nowSelect = 0;
        }
        if(_nowSelect < 0)
        {
            _nowSelect = _amount;
        }
    }

    int GetAmount()
    {
        if(Input.GetKeyDown(KeyCode.W) && _active)
        {
            _audio.Play();
            return -1;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _active)
        {
            _audio.Play();
            return 1;
        }
        return 0;
    }
    public void Pause()
    {
        _active = true;
    }
    public void Resume()
    {
        _active = false;
    }
}
