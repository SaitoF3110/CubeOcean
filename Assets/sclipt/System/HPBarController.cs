using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarController : MonoBehaviour
{
    // Start is called before the first frame update
    public float _plyerHp;
    public float _plyerMaxHp;
    float _hpRatio;
    float _defaultX;
    int x = 0;
    void Start()
    {
        _defaultX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (_plyerMaxHp != 0)
        {
            _hpRatio = _plyerHp / _plyerMaxHp * 270;
            this.transform.position = new Vector3(_hpRatio - 270 + _defaultX, this.transform.position.y, this.transform.position.z);
        }
    }
}
