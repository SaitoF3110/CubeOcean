using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    [SerializeField] GameObject _endKuro;
    [SerializeField] GameObject _per;
    float _time;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += new Vector3(1, 0, 0);
        _time += Time.deltaTime;
        if(_time > 5)
        {
            Instantiate(_endKuro, this.transform.position,this.transform.rotation,_per.transform);
            Destroy(this.gameObject);
        }
    }
}
