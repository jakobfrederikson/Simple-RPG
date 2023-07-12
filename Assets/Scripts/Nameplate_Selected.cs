using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Nameplate_Selected : MonoBehaviour
{
    public static Nameplate_Selected Instance;

    [SerializeField]
    private TextMeshProUGUI selectedNameText, health, intellect;
    [SerializeField]
    private Image icon, healthFill, intellectFill;

    private INameplate currentlySelectedObject;

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

        UIEventHandler.OnSelectedHealthChanged += UpdateHealth;
        UIEventHandler.OnSelectedIntellectChanged += UpdateIntellect;

        this.gameObject.SetActive(false);
    }

    public void OnSelected(INameplate selected)
    {
        currentlySelectedObject = selected;
        currentlySelectedObject.IsSelected = true;

        this.selectedNameText.text = selected.Name;
        UpdateHealth(selected.CurrentHealth, selected.MaxHealth);
        UpdateIntellect(selected.CurrentIntellect, selected.MaxIntellect);
        icon.sprite = Resources.Load<Sprite>("UI/Icons/Enemies/" + selected.IconSlug);
        this.gameObject.SetActive(true);        
    }

    public void OnDeselect()
    {
        currentlySelectedObject.IsSelected = false;
        currentlySelectedObject = null;
        this.gameObject.SetActive(false);
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
