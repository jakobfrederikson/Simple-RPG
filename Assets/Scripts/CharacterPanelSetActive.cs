using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanelSetActive : MonoBehaviour
{
    public RectTransform characterPanel;

    private bool characterPanelIsActive { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        characterPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            characterPanelIsActive = !characterPanelIsActive;
            characterPanel.gameObject.SetActive(characterPanelIsActive);
        }
    }
}
