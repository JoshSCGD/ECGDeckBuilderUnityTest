using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Card", menuName = "Scriptable Objects/SO_Card")]
public class SO_Card : ScriptableObject
{
    [field: SerializeField, BoxGroup("Visuals")] public string Name { get; private set; } = "Card Name";
    [field: SerializeField, BoxGroup("Visuals")] public Sprite Illustration { get; private set; }
    [field: SerializeField, BoxGroup("Visuals")] public string Description { get; private set; } = "Card Description";
    
    [field: SerializeField, MinValue(0), BoxGroup("Stats")] public float Health { get; private set; }
    [field: SerializeField, MinValue(0), BoxGroup("Stats")] public float Damage { get; private set; }
    [field: SerializeField, MinValue(0), BoxGroup("Stats")] public int Cost { get; private set; }
    [field: SerializeField,BoxGroup("Stats")] public E_DamageType DamageType { get; private set; }
    
}