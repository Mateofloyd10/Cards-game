using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardsManager : MonoBehaviour
{
    public Sprite[] imagenes;
    public string[] attackName;
    public string[] descriptionName;
    public string[] numberName;
    public Sprite[] BgCards;
    public Image CardImage;
    public Image CardBG;
    public TMP_Text CardAttackText;
    public TMP_Text CardDescriptionText;
    public TMP_Text CardNumberText;

    private void Start()
    {
        CardImage.sprite = imagenes[GameManager.numerGlobal];
        CardAttackText.text = attackName[GameManager.numerGlobal];
        CardDescriptionText.text = descriptionName[GameManager.numerGlobal];
        CardNumberText.text = numberName[GameManager.numerGlobal];
        CardBG.sprite = BgCards[GameManager.numerGlobal];

        gameObject.name = CardNumberText.text;
        if (GameManager.numerGlobal < 2)
        {
            gameObject.tag = "Attack";
        }
        else 
        {
            gameObject.tag = "Defense";
        }

        GameManager.numerGlobal++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            GameManager.globalColisionDefense = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            GameManager.globalColisionDefense = true;
        }
    }
}
