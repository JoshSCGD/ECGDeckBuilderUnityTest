using UnityEngine;

[CreateAssetMenu(fileName = "SO_Card", menuName = "Scriptable Objects/SO_Card")]
public class SO_Card : ScriptableObject
{
    //ensured that all vars are public getters and private setters to prevent potential error down the line
    public string Name { get; private set; } = "Card Name";
    [Min(0)] public int Cost { get; private set; } 
    [Min(0)] public float Damage { get; private set; }
    public E_DamageType DamageType { get; private set; } 
    [Min(0)] public float Health { get; private set; } 
    public Sprite Illustration { get; private set; }
    public string Description { get; private set; } = "Card Description";
}
