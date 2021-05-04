using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    private float _speed = 1.0f;
    private bool _switch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, Time.deltaTime * _speed);
        }
        else if(_switch == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, Time.deltaTime * _speed);
        }
        if (transform.position.x == _pointB.transform.position.x)
        {
            _switch = true;
        }
        else if (transform.position.x == _pointA.transform.position.x)
        {
            _switch = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

}
