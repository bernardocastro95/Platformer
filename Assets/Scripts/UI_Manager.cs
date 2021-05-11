using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _ammo;
    [SerializeField]
    private GameObject _coin;
    public void UpdateAmmo(int ammo)
    {
        _ammo.text = "Ammo: " + ammo;
    }
    public void ShowCoin()
    {
        _coin.SetActive(true);
    }
}
