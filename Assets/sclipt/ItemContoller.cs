using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContoller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _se;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject _playerObj = GameObject.FindWithTag("Player");
        this.transform.rotation = _playerObj.transform.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(_se);
            Destroy(this.gameObject);
        }
    }
}
