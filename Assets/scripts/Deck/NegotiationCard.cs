using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New NegotiationCard", menuName = "NegotiationCard")]
public class NegotiationCard : Card
{
    public PlayableCharacter character;
    public int numberOfDice;
    public int sidedDice;
    public int diceModifier;
    public List<NegotiationSubType> subTypes;

    public enum PlayableCharacter
    {
        Pixie,
        Baldwin,
        Barley
    }

    public enum NegotiationSubType
    {
        Diplomacy,
        Intimidation,
        Bribery,
        Buff,
        Debuff
    }
}
