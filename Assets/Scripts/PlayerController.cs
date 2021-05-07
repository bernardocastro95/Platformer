﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    [SerializeField]
    private ParticleSystem _shot;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _shot = GameObject.Find("Muzzle_Flash").GetComponentInParent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetMouseButtonDown(0))
        {
            
            Ray origin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            _shot.Play(true);

            if (Physics.Raycast(origin, out hit))
            {
                Debug.Log("HIT: " + hit.transform.name);
            }
        }
        else
        {
            _shot.Stop(true);
        }

        if (Cursor.visible == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        MovementPlayer();

       

    }
    void MovementPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        Vector3 vel = dir * _speed;
        vel.y -= _gravity;
        vel = transform.transform.TransformDirection(vel);
        _controller.Move(vel * Time.deltaTime);
    }
}
