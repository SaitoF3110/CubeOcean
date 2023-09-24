using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string _scene;
    [SerializeField] float _weitTime = 0;
    float _time;
    bool _loadCommandOn = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_loadCommandOn)
        {
            _time += Time.deltaTime;
            if(_time > _weitTime)
            {
                SceneManager.LoadScene(_scene);
            }
        }
    }
    public void LoadSceneM()
    {
        _loadCommandOn = true;
    }
}
