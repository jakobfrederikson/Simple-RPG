using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
    private NavMeshAgent playerAgent;

    private void Awake()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Get interaction with world as long as our pointer is on a game object
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }

        if (playerAgent.velocity.magnitude > 0f || playerAgent.velocity.magnitude < 0f)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                playerAgent.destination = playerAgent.transform.position;
            }
        }
    }

    private void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            playerAgent.updateRotation = true;
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.CompareTag("Enemy"))
            {
                Debug.Log("Move to enemy");
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
                CheckNameplate(interactedObject);
            }
            else if (interactedObject.CompareTag("Interactable Object"))
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
                CheckNameplate(interactedObject);
            }
            else
            {
                Nameplate_Selected.Instance.OnDeselect();
                playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }

    private void CheckNameplate(GameObject interactedObject)
    {
        if (interactedObject.GetComponent<INameplate>() != null)
        {
            INameplate selected = interactedObject.GetComponent<INameplate>();
            Debug.Log("Selected NPC: " + selected.Name);
            Debug.Log("Selected NPC: " + selected.CurrentHealth + " / " + selected.MaxHealth);
            Nameplate_Selected.Instance.OnSelected(selected);
        }
    }
}
