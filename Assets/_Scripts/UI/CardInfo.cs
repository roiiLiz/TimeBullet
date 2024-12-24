using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Image cardImage;
    [SerializeField]
    private TextMeshProUGUI cardTitle;
    [SerializeField]
    private TextMeshProUGUI cardDescription;
    [SerializeField]
    private BasePowerUp cardAbility;

    public static event Action selectedCard;

    public void SetCard(Sprite incomingImage, string incomingTitle, string incomingDescription, BasePowerUp incomingAbility)
    {
        cardImage.sprite = incomingImage;
        cardTitle.text = incomingTitle;
        cardDescription.text = incomingDescription;
        cardAbility = incomingAbility;
    }
    
    public void ApplyPowerUp()
    {
        cardAbility.AddToList(cardAbility);
        selectedCard?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
