using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    public static DamagePopUp Create(Vector3 position, string damageAmount)
    {
        Transform damagePopUpTransform = Instantiate(GameAssets.i.pfdamagePopUp, position, Quaternion.identity);
        DamagePopUp damagePopUpScrip = damagePopUpTransform.GetComponentInChildren<DamagePopUp>();
        damagePopUpScrip.SetUp(damageAmount);
       
        return damagePopUpScrip;
    }

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void SetUp(string damageAmount)
    {
        textMesh.SetText(damageAmount);
        textColor = textMesh.color;
        disappearTimer = .2f;
    }

    private void Update()
    {
        float moveYSpeed = 5f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            //Start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
