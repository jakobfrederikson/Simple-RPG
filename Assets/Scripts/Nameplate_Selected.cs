using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Nameplate_Selected : MonoBehaviour
{
    public static Nameplate_Selected Instance;

    private string selectedName;
    private TextMeshProUGUI selectedNameText, health, intellect;
    private Image icon, healthFill, intellectFill;

    public Nameplate_Selected(string _selectedName, TextMeshProUGUI _selectedNameText,
        TextMeshProUGUI _health, TextMeshProUGUI _intellect, Image _icon,
        Image _healthFill, Image _intellectFill)
    {
        this.selectedName = _selectedName;
        this.health = _health;
        this.intellect = _intellect;
        this.icon = _icon;
        this.healthFill = _healthFill;
        this.intellectFill = _intellectFill;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        //UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        //UIEventHandler.OnPlayerIntellectChanged += UpdateIntellect;
        this.gameObject.SetActive(false);

        if (GetComponent<IEnemy>() != null)
        {
            // if enemy, set their colour to red to show is BAD!!!
            transform.Find("Background_Image").GetComponent<Image>().color = new Color32(173, 6, 9, 100);
        }
    }

    public void OnSelected()
    {
        this.gameObject.SetActive(true);
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
