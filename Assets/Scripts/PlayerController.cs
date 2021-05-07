using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (Cursor.visible == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray origin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(origin, out hit))
            {
                Debug.Log("HIT: " + hit.transform.name);
            }
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
