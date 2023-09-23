using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToMousePotion : MonoBehaviour
{
    [SerializeField] Vector3 _differential;
    Vector3 _default;
    void Start()
    {
        _default = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(Input.mousePosition.x + _differential.x,Input.mousePosition.y + _differential.y,_differential.z);
    }
    public void SetActiveScale(bool _boolen)
    {
        if(_boolen)
        {
            transform.localScale = _default;
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
