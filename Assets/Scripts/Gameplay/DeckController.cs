using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DeckController : MonoBehaviour
{
    [SerializeField, Required] private List<PSO_Card> _cardData;
    [SerializeField, Required] private GameObject _baseCardPrefab;
    [SerializeField, Required] private HandController _handController;

    private int _currentIndex;
    
    //dispatchers
    public UnityEvent <int> OnDrawCard;
    public UnityEvent OnShuffleCard;
    
    private void Start()
    {
        Shuffle();
    }

    public void DrawCard()
    {
        if (_currentIndex >= _cardData.Count) return;
        
        if (_handController.IsFull) return;
        
        PSO_Card data = _cardData[_currentIndex];
        _currentIndex++;

        GameObject obj = Instantiate(_baseCardPrefab, transform.position, Quaternion.identity);

        Card card = obj.GetComponent<Card>();
        card.Initialize(data);

        _handController.AddCard(card);

        OnDrawCard?.Invoke(_currentIndex);
    }

    public void Shuffle()
    {
        for (int i = 0; i < _cardData.Count; i++)
        {
            int rand = Random.Range(i, _cardData.Count);
            (_cardData[i], _cardData[rand]) = (_cardData[rand], _cardData[i]);
        }
        
        OnShuffleCard?.Invoke();
    }
}