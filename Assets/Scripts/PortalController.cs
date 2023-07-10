using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    private Button button;
    private Player player;
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        panel = this.transform.Find("Panel_Portal").gameObject;
        panel.SetActive(false);
    }

    public void ActivatePortal(Portal[] portals)
    {
        panel.SetActive(true);

        for (int i = 0; i < portals.Length; i++)
        {
            Button portalButton = Instantiate(button, panel.transform);
            portalButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = portals[i].name;
            int x = i;
            portalButton.onClick.AddListener(delegate { OnPortalButtonClick(portals[x]); });
        }
    }

    private void OnPortalButtonClick(Portal portal)
    {
        player.transform.position = portal.TeleportLocation;
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            if (button.gameObject.name != "CancelButton")
                Destroy(button.gameObject);
        }
        panel.SetActive(false);
    }

    public void OnCancelButtonClick()
    {
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            if (button.gameObject.name != "CancelButton")
                Destroy(button.gameObject);
        }
        panel.SetActive(false);
    }
}
