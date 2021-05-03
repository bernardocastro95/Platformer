using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jump = 35.0f;
    private float _yVelocity;
    private bool _doubleJump = false;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(horizontal * _speed, 0, 0);
       

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jump;
                _doubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(_doubleJump == true)
                {
                    _yVelocity = _jump;
                    _doubleJump = false;
                }
                
            }
            _yVelocity -= _gravity;
        }
        dir.y = _yVelocity;
        _controller.Move(dir * Time.deltaTime);

        

    }
}
