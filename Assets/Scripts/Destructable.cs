using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject _crateCracked;

    public void DestroyCrate()
    {
        Instantiate(_crateCracked, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
