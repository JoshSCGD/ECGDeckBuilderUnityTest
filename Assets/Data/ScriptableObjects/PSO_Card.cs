using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Card", menuName = "Scriptable Objects/SO_Card")]
public class PSO_Card : ScriptableObject //i added a prefix of "P" for primary (im used to PDA's in unreal, which are primary data assets) 
{
    public enum E_CardType
    {
        Unit,
        Spell,
    }
    //Visuals fields 
    [field: SerializeField, BoxGroup("Visuals")] public string Name { get; private set; } = "Card Name";
    [field: SerializeField, BoxGroup("Visuals")] public Sprite Illustration { get; private set; }
    [field: SerializeField, BoxGroup("Visuals")] public string Description { get; private set; } = "Card Description";
   
    //Stat fields 
    [field: SerializeField, MinValue(0), BoxGroup("Stats")] public int Cost { get; private set; }
    [field: SerializeField, BoxGroup("Stats")] public E_CardType CardType { get; private set;}
    
    [field: SerializeField, MinValue(0), BoxGroup("Stats"), ShowIf("CardType", E_CardType.Unit)] 
        public float Damage { get; private set; }
    
    [field: SerializeField, MinValue(0), BoxGroup("Stats"), ShowIf("CardType", E_CardType.Unit)] 
        public float Health { get; private set; }
    
    [field: SerializeField,BoxGroup("Stats"), ShowIf("CardType", E_CardType.Unit)] 
        public E_DamageType DamageType { get; private set; }
}