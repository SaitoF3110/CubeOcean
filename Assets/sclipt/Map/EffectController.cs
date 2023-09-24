using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _effect;
    [SerializeField] float _effectTime;
    float _time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //常にプレイヤーの位置を取得
        GameObject _playerObj = GameObject.FindWithTag("Player");
        this.transform.rotation = _playerObj.transform.rotation;

    }
    private void FixedUpdate()
    {
        _time += Time.deltaTime;
        if (_time < _effectTime)
        {
            Vector3 _trans = new Vector3(this.transform.position.x + Random.Range(-1.5f, 1.5f), this.transform.position.y + Random.Range(-1.5f, 1.5f), 0.0f);
            Instantiate(_effect, _trans, this.transform.rotation, this.gameObject.transform);
        }
        else
        {
            if (_time > _effectTime + 2)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
