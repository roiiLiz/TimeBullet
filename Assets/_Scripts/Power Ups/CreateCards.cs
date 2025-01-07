using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private bool reroll = false;
    
    private void OnEnable() {  PlayerEXP.levelUp += GenerateCards; }
    private void OnDisable() {  PlayerEXP.levelUp -= GenerateCards; }

    private void GenerateCards()
    {
        for (int i = 0; i < cardsToGenerate; i++)
        {
            int randomCard = UnityEngine.Random.Range(0, cards.Count - 1);

            GameObject newCard = Instantiate(cardPrefab);
            newCard.transform.SetParent(cardPanel);
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.transform.localPosition = new Vector3((i + 2 - cardsToGenerate) * cardXSpacing, 0, 0);

            newCard.GetComponent<CardInfo>().SetCard(cards[randomCard].image, cards[randomCard].title, cards[randomCard].description, cards[randomCard].powerUp);
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