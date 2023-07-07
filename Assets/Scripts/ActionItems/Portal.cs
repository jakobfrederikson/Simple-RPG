using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ActionItem
{
    public Vector3 TeleportLocation { get; set; }

    [SerializeField]
    private Portal[] linkedPortals;
    private PortalController PortalController { get; set; }

    private void Awake()
    {
        PortalController = FindObjectOfType<PortalController>();
    }

    void Start()
    {
        TeleportLocation = transform.Find("SpawnLocation").transform.position;
    }

    public override void Interact()
    {
        PortalController.ActivatePortal(linkedPortals);
        playerAgent.ResetPath();
    }
}
