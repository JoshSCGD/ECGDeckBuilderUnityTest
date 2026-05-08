using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private bool _debugData = false; 
    [SerializeField, ShowIf("_debugData")]  private PSO_Card _cardData; // a field here for easy debugging
    [SerializeField, Required] private SpriteRenderer _illustration; // the following vars are required, or else stuff breaks
    [SerializeField, Required] private TextMeshPro _cardName;
    
    public PSO_Card CardData => _cardData; // a convenient getter if needed 

    private void OnValidate()  // updates illustration in the scene 
    {
        if (!_debugData) return; //some errors were getting thrown in editor and while that should be fine, I validated them to be safe

        if (_cardData == null)
            return;
        
        Initialize(_cardData);
    }

    private void OnMouseDown()
    {
        print("hello");
    }


    public void Initialize(PSO_Card cardData) // this is a func that the deck will call to initialize the card data
    {
        if(cardData == null) return;
        
        _cardData = cardData;
        _illustration.sprite = _cardData.Illustration;
        _cardName.text = _cardData.Name;

    }
    
    
}