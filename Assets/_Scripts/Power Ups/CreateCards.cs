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
    
    private List<int> randomCards = new List<int>();
    private bool keepGenerating;
    private int selectableCards = 0;

    private void OnEnable() {  PlayerEXP.levelUp += GenerateCards; TimeUpgrade.removeTimeSelection += RemovePowerUp; }
    private void OnDisable() {  PlayerEXP.levelUp -= GenerateCards; TimeUpgrade.removeTimeSelection -= RemovePowerUp; }

    private void RemovePowerUp(string powerUpToRemove)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].powerUp.name == powerUpToRemove)
            {
                cards[i].selectable = false;
            }
        }
    }

    private void GenerateRandomSelection(int selectionCount)
    {
        randomCards.Clear();
        
        keepGenerating = true;
        while (keepGenerating)
        {
            int randomSelection = UnityEngine.Random.Range(0, cards.Count);
            if (randomCards.Contains(randomSelection) == false && cards[randomSelection].selectable == true)
            {
                Debug.Log($"Adding to Selection: {randomSelection}");
                randomCards.Add(randomSelection);
            }

            if (randomCards.Count == selectionCount)
            {
                keepGenerating = false;
            }
        }
        
    }

    private void GenerateCards()
    {
        GenerateRandomSelection(cardsToGenerate);

        for (int i = 0; i < randomCards.Count; i++)
        {
            // int randomCard = UnityEngine.Random.Range(0, cards.Count - 1);

            GameObject newCard = Instantiate(cardPrefab);
            newCard.transform.SetParent(cardPanel);
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.transform.localPosition = new Vector3((i + 2 - cardsToGenerate) * cardXSpacing, 0, 0);

            newCard.GetComponent<CardInfo>().SetCard(cards[randomCards[i]].image, cards[randomCards[i]].title, cards[randomCards[i]].description, cards[randomCards[i]].powerUp);
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
    public bool selectable = true;
}