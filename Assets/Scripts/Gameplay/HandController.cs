using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private Transform _handOrigin;
    [SerializeField,MinValue(0)] private float _spacing = 1.5f;
    [MinValue(0)] public int _maxCards { get; private set; } = 8;

    private List<Card> _cards = new List<Card>();

    public bool IsFull => _cards.Count >= _maxCards;

    public void AddCard(Card card)
    {
        if (IsFull) return;

        _cards.Add(card);

        int index = _cards.Count - 1;

        Vector3 pos = _handOrigin.position + new Vector3(index * _spacing, 0, 0);
        card.transform.position = pos;
    }
    
}