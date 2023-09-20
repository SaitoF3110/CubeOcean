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
        _defaultX = this.transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (_plyerMaxHp != 0)
        {
            _hpRatio = _plyerHp / _plyerMaxHp * 100;
            this.transform.localPosition = new Vector3(_hpRatio - 100 + _defaultX, this.transform.localPosition.y, this.transform.localPosition.z);
        }
    }
}
