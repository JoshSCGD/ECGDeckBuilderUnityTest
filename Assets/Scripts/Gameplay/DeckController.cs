using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    [SerializeField, Required] private List<PSO_Card> _cardData;
    [SerializeField, Required] private GameObject _cardViewPrefab;

    private int _currentIndex;

    private void Start()
    {
        Shuffle();
        DrawCard();
        DrawCard();
    }

    public void DrawCard()
    {
        if (_currentIndex >= _cardData.Count) return;
        
        PSO_Card data = _cardData[_currentIndex];
        _currentIndex++;

        GameObject obj = Instantiate(_cardViewPrefab, transform.position, Quaternion.identity);

        Card card = obj.GetComponent<Card>();
        card.Initialize(data);
    }

    public void Shuffle()
    {
        for (int i = 0; i < _cardData.Count; i++)
        {
            int rand = Random.Range(i, _cardData.Count);
            (_cardData[i], _cardData[rand]) = (_cardData[rand], _cardData[i]);
        }
    }
}