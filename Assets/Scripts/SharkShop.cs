using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerController p = other.GetComponent<PlayerController>();
                if(p!= null)
                {
                    if(p._hasCoin == true)
                    {
                        p._hasCoin = false;
                        UI_Manager ui = GameObject.Find("Canvas").GetComponent<UI_Manager>();
                        if(ui != null)
                        {
                            ui.RemoveCoin();
                            AudioSource source = GetComponent<AudioSource>();
                            source.Play();
                            p.EnableWeapon();
                        }
                    }
                    else
                    {
                        Debug.Log("This is not charity. Want the weapon ? Pay for it");
                    }
                }
            }
        }
    }
}
