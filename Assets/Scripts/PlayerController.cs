using System.Collections;
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
    [SerializeField]
    private GameObject _hitMarker;
    [SerializeField]
    private AudioSource _shotSource;
    [SerializeField]
    private int ammo;
    private int max = 200;
    private bool _reloading = false;
    private UI_Manager _manager;
    public bool _hasCoin = false;
    [SerializeField]
    private GameObject _weapon;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       _shot = GameObject.Find("Muzzle_Flash").GetComponentInParent<ParticleSystem>();
        ammo = max;
        _manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetMouseButton(0) && ammo > 0 && _weapon.activeSelf == true)
        {
            Shooter();
        }
        else
        {
            _shot.Stop(true);
            _shotSource.Stop();
        }

        if (Cursor.visible == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        MovementPlayer();

        if (Input.GetKeyDown(KeyCode.R) && _reloading == false)
        {
            _reloading = true;
            StartCoroutine(Reloader());
        }

       

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

    void Shooter()
    {
        ammo--;
        _manager.UpdateAmmo(ammo);
        Ray origin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (!_shot.isPlaying)
        {
            /*code in case of audio issues

            if(_shotSource.isPlaying == false) 
            {
                _shotSource.Play();
            }

             */
            _shot.Play(true);

            _shotSource.Play();
        }
        if (Physics.Raycast(origin, out hit))
        {
            Debug.Log("HIT: " + hit.transform.name);
            GameObject laserHitted = Instantiate(_hitMarker, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            Destroy(laserHitted, 1f);

            Destructable crate = hit.transform.GetComponent<Destructable>();
            if(crate != null)
            {
                crate.DestroyCrate();
            }

        }
    }
    IEnumerator Reloader()
    {
        yield return new WaitForSeconds(5.0f);
        ammo = max;
        _manager.UpdateAmmo(ammo);
        _reloading = false;
    }

    public void EnableWeapon()
    {
        _weapon.SetActive(true);
        _shot.Play(false);
    }
}
