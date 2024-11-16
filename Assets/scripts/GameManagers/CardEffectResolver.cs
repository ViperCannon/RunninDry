using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeakeasyStreet
{
    public class CardEffectResolver : MonoBehaviour
    {
        public void ResolveCardEffect(Card card, CharacterInstance target)
        {
            // Check card type and resolve the corresponding effect
            switch (card.cardType)
            {
                case Card.CardType.Combat:
                    ResolveCombatCard(card, target);
                    break;

                case Card.CardType.Negotiation:
                    ResolveNegotiationCard(card, target);
                    break;
            }
        }

        // Resolve Combat Card Effects
        private void ResolveCombatCard(Card card, CharacterInstance target)
        {
            // Example: Apply damage based on card attributes
            if (card.damage != 0)
            {
                ApplyDamage(card, target);
            }
            if (card.subTypes.Contains(Card.SubType.Buff))
            {
                ApplyBuff(card, target);
            }
            if (card.subTypes.Contains(Card.SubType.Debuff))
            {
                ApplyDebuff(card, target);
            }
        }

        // Resolve Negotiation Card Effects (e.g., Diplomacy, Intimidation, etc.)
        private void ResolveNegotiationCard(Card card, CharacterInstance character)
        {
            if (card.subTypes.Contains(Card.SubType.Diplomacy))
            {
                AttemptDiplomacy(card, character);
            }
            if (card.subTypes.Contains(Card.SubType.Intimidation))
            {
                AttemptIntimidation(card, character);
            }
            if (card.subTypes.Contains(Card.SubType.Bribery))
            {
                AttemptBribery(card, character);
            }
        }

        // Apply damage to a random enemy (or specific target if desired)
        private void ApplyDamage(Card card, CharacterInstance target)
        {
            int totalDamage = card.damage;
            // Add additional logic to handle dice rolls

            target.TakeDamage(totalDamage);

        }

        // Roll dice logic
        private int RollDice(int numberOfDice, int sidedDice, int diceModifier)
        {
            int total = 0;
            for (int i = 0; i < numberOfDice; i++)
            {
                total += Random.Range(1, sidedDice + 1);
            }
            return total + diceModifier;
        }

        // Apply buffs to the player
        private void ApplyBuff(Card card, CharacterInstance character)
        {
            // Buff logic here.
        }

        // Apply debuffs to the enemies
        private void ApplyDebuff(Card card, CharacterInstance character)
        {
            // Debuff logic here.
        }

        // Negotiation Subtype Effects
        private void AttemptDiplomacy(Card card, CharacterInstance character)
        {

        }

        private void AttemptIntimidation(Card card, CharacterInstance character)
        {

        }

        private void AttemptBribery(Card card, CharacterInstance character)
        {

        }
    }
}
