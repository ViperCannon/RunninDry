using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeakeasyStreet
{
    public class CardEffectResolver : MonoBehaviour
    {
        CombatManager cManager;

        void Start()
        {
            cManager = GetComponent<CombatManager>();
        }

        public void ResolveTargetCardEffect(Card card, CharacterInstance target, int cost)
        {
            // Example: Apply damage based on card attributes
            if (card.damage != 0)
            {
                ApplyDamage(card, target, cost);
            }
            if (card.subTypes.Contains(Card.SubType.Buff))
            {
                ApplyBuff(card, target, cost);
            }
            if (card.subTypes.Contains(Card.SubType.Debuff))
            {
                ApplyDebuff(card, target, cost);
            }
        }

        // Resolve Combat Card Effects
        public void ResolveNonTargetCardEffect(Card card, int cost)
        {
            switch (card.validTargets[0])
            {
                case Card.CardTarget.AllEnemies:

                    AllEnemiesEffect(card, cost);

                    break;

                case Card.CardTarget.AllPlayers:

                    AllPlayersEffect(card, cost);

                    break;

                case Card.CardTarget.AllCharacters:

                    AllEnemiesEffect(card, cost);
                    AllPlayersEffect(card, cost);

                    break;

                default: //handle generic

                    break;
            }
        }

        private void AllEnemiesEffect(Card card, int cost)
        {
            foreach (EnemyInstance e in cManager.enemies)
            {
                if (!e.isDowned)
                {
                    if (card.damage != 0)
                    {
                        ApplyDamage(card, e, cost);
                    }
                    if (card.subTypes.Contains(Card.SubType.Buff))
                    {
                        ApplyBuff(card, e, cost);
                    }
                    if (card.subTypes.Contains(Card.SubType.Debuff))
                    {
                        ApplyDebuff(card, e, cost);
                    }
                }
            }
        }

        private void AllPlayersEffect(Card card, int cost)
        {
            foreach (AllyInstance p in cManager.players)
            {
                if (!p.isDowned)
                {
                    if (card.damage != 0)
                    {
                        ApplyDamage(card, p, cost);
                    }
                    if (card.subTypes.Contains(Card.SubType.Buff))
                    {
                        ApplyBuff(card, p, cost);
                    }
                    if (card.subTypes.Contains(Card.SubType.Debuff))
                    {
                        ApplyDebuff(card, p, cost);
                    }
                }
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
        private void ApplyDamage(Card card, CharacterInstance target, int cost)
        {
            for(int i = 0; i < card.damageMulti; i++)
            {
                int totalDamage = card.damage * cost;
                // Add additional logic to handle dice rolls

                target.TakeDamage(totalDamage);
            }
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
        private void ApplyBuff(Card card, CharacterInstance character, int cost)
        {
            // Buff logic here.
        }

        // Apply debuffs to the enemies
        private void ApplyDebuff(Card card, CharacterInstance character, int cost)
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
