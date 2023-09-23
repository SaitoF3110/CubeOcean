using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectController : MonoBehaviour, IPause
{
    // Start is called before the first frame update
    [SerializeField] Transform[] transforms;
    [SerializeField] GameObject[] _objects;
    Vector3[] _defaultScale = new Vector3[4];
    AudioSource _audio;
    int _amount;//ëIëéàÇÃêî
    int _nowSelect;
    bool _active;
    void Awake()
    {
        _amount = transforms.Length - 1;
        for (int i = 0; i < _amount; i++)
        {
            _defaultScale[i] = _objects[i].transform.localScale;
        }
    }
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _nowSelect += GetAmount();
        CountFix();
        ShowUI();
        this.transform.position = transforms[_nowSelect].position;
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(_nowSelect);
        }
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
    void ShowUI()
    {
        if (_active)
        {
            for (int i = 0; i < _amount; i++)
            {
                if (i == _nowSelect)
                {
                    _objects[i].transform.localScale = _defaultScale[i];
                }
                else
                {
                    _objects[i].transform.localScale = new Vector3(0, 0, 0);
                }
            }
        }
    }
}
