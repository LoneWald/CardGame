using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScript : MonoBehaviour
{
    public Card SelfCard;
    public TextMeshProUGUI Name;
    public Image Logo;
    
    public void HideCardInfo(Card card)
    {
        //SelfCard = card;
        //Logo.sprite = null;
        //Name.text = "?????";
        ShowCardInfo(card);
    }

    public void ShowCardInfo(Card card)
    {
        SelfCard = card;

        Logo.sprite = card.Logo;
        Logo.preserveAspect = true;
        Name.text = card.Name;
    }

    private void Start() {
        //ShowCardInfo(CardManager.AllCards[transform.GetSiblingIndex()]);
    }
}
