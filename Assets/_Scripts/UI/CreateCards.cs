using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCards : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private Transform cardPanel;
    [SerializeField]
    private List<Card> cards = new List<Card>();

    [SerializeField]
    private int cardsToGenerate = 3;
    [SerializeField]
    private int cardXSpacing = 350;
    
    private void OnEnable() {  PlayerEXP.levelUp += GenerateCards; }
    private void OnDisable() {  PlayerEXP.levelUp -= GenerateCards; }

    private void GenerateCards()
    {
        for (int i = 0; i < cardsToGenerate; i++)
        {
            GameObject newCard = Instantiate(cardPrefab);
            newCard.transform.SetParent(cardPanel);
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.transform.localPosition = new Vector3((i + 2 - cardsToGenerate) * cardXSpacing, 0, 0);

            newCard.GetComponent<CardInfo>().SetCard(cards[i].image, cards[i].title, cards[i].description, cards[i].powerUp);
        }
    }
}

[Serializable]
public class Card
{
    public Sprite image;
    public string title;
    [TextArea(5, 10)]
    public string description;
    public BasePowerUp powerUp;
}