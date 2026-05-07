using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private bool _debugData = false; 
    [SerializeField, ShowIf("_debugData")]  private SO_Card _cardData; // despite the deck initializing the cards, I kept a field here for easy debugging in the scene 
    [SerializeField, Required] private SpriteRenderer _illustration; // the following vars are required, or else stuff breaks
    
    public SO_Card CardData => _cardData; // a convenient getter if needed 

    private void OnValidate()  // updates illustration in the scene 
    {
        if (!_debugData) return; //some errors were getting thrown in editor and while that should be fine, I validated them to be safe

        if (_cardData == null)
            return;

        if (_cardData.Illustration == null)
            return;

        _illustration.sprite = _cardData.Illustration;
    }

    public void Initialize(SO_Card cardData) // this is a func that the deck will call to initialize the card data
    {
        if (cardData == null || _illustration == null)
            return;

        _cardData = cardData;
        _illustration.sprite = _cardData.Illustration;
    }
}