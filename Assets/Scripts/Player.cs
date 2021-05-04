using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private int _coins;
    private UIManager _ui;
    private int _lifes = 3;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_ui == null)
        {
            Debug.LogError("UI Manager NULL");
        }
        _ui.UpdateLivesDisplay(_lifes);
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

        if(transform.position.y >= -10)
        {

        }

    }

    public void AddCoins()
    {
        _coins++;
        _ui.UpdateCoinsDisplay(_coins);
    }
    public void RemoveLife()
    {
        _lifes--;
        _ui.UpdateLivesDisplay(_lifes);

        if(_lifes < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
