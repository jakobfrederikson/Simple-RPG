using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameplate : MonoBehaviour
{
    [SerializeField] private string PlayerName;
    [SerializeField] private TextMeshProUGUI playerName, health, intellect;
    [SerializeField] private Image healthFill, intellectFill;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnPlayerIntellectChanged += UpdateIntellect;
        UpdateHealth(player.currentHealth, player.maxHealth);
        UpdateIntellect(player.currentIntellect, player.maxIntellect);
        playerName.text = PlayerName;
    }

    private void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    private void UpdateIntellect(int currentIntellect, int maxIntellect)
    {
        this.intellect.text = currentIntellect.ToString() + " / " + maxIntellect.ToString();
        this.intellectFill.fillAmount = (float)currentIntellect / (float)maxIntellect;
    }
}
