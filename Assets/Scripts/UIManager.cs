using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText, _lifeText;
    public void UpdateCoinsDisplay(int coins)
    {
        _coinText.text = "Coins: " + coins.ToString();
    }
    public void UpdateLivesDisplay(int lives)
    {
        _lifeText.text = "Lives: " + lives.ToString();
    }
}
