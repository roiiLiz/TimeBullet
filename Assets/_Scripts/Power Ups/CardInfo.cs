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
    [SerializeField]
    private bool selectable = true;

    public static event Action selectedCard;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetCard(Sprite incomingImage, string incomingTitle, string incomingDescription, BasePowerUp incomingAbility)
    {
        cardImage.sprite = incomingImage;
        cardTitle.text = incomingTitle;
        cardDescription.text = incomingDescription;
        cardAbility = incomingAbility;
    }

    public void ApplyPowerUp()
    {
        PowerUpType abilityPower = cardAbility.ReturnType();

        switch(abilityPower)
        {
            case PowerUpType.MOVEMENT:
                cardAbility.ApplyPowerUp(player);
                break;
            case PowerUpType.BULLET:
                player.GetComponent<PlayerFiring>().bulletUpgrades.Add(cardAbility);
                break;
            case PowerUpType.TIME:
                cardAbility.ApplyPowerUp(player);
                break;
            case PowerUpType.HEALTH:
                break;
            case PowerUpType.META:
                break;
            default:
                break;
        }

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
