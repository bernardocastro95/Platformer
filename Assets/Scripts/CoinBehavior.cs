using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;
   


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerController p = other.GetComponent<PlayerController>();
                if(p != null)
                {
                    p._hasCoin = true;
                    AudioSource.PlayClipAtPoint(_clip, transform.position, 1f);
                    UI_Manager manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

                    if(manager != null)
                    {
                        manager.ShowCoin();
                    }
                    Destroy(this.gameObject);
                }
            }
        }
           
    }
}
