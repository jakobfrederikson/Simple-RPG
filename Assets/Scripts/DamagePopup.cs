using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColour;
    private Transform playerTransform;

    private float disappearTimer = 0.5f;
    private float fadOutSpeed = 5f;
    private float moveYSpeed = 1f;

    public void SetUp(int amount)
    {
        textMesh = GetComponent<TextMeshPro>();
        playerTransform = Camera.main.transform;
        textColour = textMesh.color;
        textMesh.SetText(amount.ToString());
    }

    private void LateUpdate()
    {
        transform.LookAt(2 * transform.position - playerTransform.position);
        transform.position += new Vector3(0f, moveYSpeed * Time.deltaTime, 0f);

        disappearTimer -= Time.deltaTime;

        if (disappearTimer <= 0f)
        {
            textColour.a -= fadOutSpeed * Time.deltaTime;
            textMesh.color = textColour;
            if (textColour.a <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
