using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class WinEvents : MonoBehaviour
{
    [SerializeField] private DeckController _deckController;
    [SerializeField] private HandController _handController;
    [SerializeField] private GameObject[] _gameObjectsToActivate;

    private void Start()
    {
        _deckController.OnDrawCard.AddListener(OnDrawCard);
    }

    public void OnDrawCard(int totalDrawnCards)
    {
        if (totalDrawnCards >= _handController._maxCards) //if reached max amount of allowed cards, activate owner
        {
            foreach (var card in _gameObjectsToActivate)
            {
                card.SetActive(true);
            }
        }
    }
}
