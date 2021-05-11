using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _ammo;
    public void UpdateAmmo(int ammo)
    {
        _ammo.text = "Ammo: " + ammo;
    }
}
