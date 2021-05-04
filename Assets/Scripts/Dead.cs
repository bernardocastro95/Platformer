using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawn;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player p = other.GetComponent<Player>();

            if(p != null)
            {
                p.RemoveLife();  
            }
            CharacterController cc = other.GetComponent<CharacterController>();
            if(cc != null)
            {
                cc.enabled = false;
            }
            other.transform.position = _respawn.transform.position;
            StartCoroutine(CCEnabler(cc));
           
        }
    }
    IEnumerator CCEnabler(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
