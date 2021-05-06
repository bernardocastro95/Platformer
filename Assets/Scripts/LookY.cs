using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 rot = transform.localEulerAngles;
        rot.x += mouseY * _sensitivity;
        /*rot.x -= mouseY * _sensitivity; Apply this line if camera's movement is inverted*/
        transform.localEulerAngles = rot;
    }
}
