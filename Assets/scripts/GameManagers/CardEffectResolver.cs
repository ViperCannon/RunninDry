using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeakeasyStreet
{
    public class CardEffectResolver : MonoBehaviour
    {
        public static CardEffectResolver Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void ResolveCardEffects(CardDisplay cardInstance, CharacterInstance target)
        {
            if (cardInstance is CombatCardDisplay)
            {
                CombatCardDisplay card = (CombatCardDisplay)cardInstance;

                foreach (ICardEffect effect in card.cardData.GetCardEffects())
                {
                    effect.ResolveEffect(card, target);
                }


                CombatBuffAndDebuffHelper(card.cardData, target);
            }
            else
            {
                NegotiationCardDisplay card = (NegotiationCardDisplay)cardInstance;

                Debug.Log(card.cardData.GetCardEffects().Count);

                foreach (ICardEffect effect in card.cardData.GetCardEffects())
                {
                    Debug.Log("resolving");
                    effect.ResolveEffect(card);
                }

                /*foreach (IBuffEffect effect in card.cardData.GetBuffEffects())
                {
                    effect.ResolveEffect(card);
                }*/
            }

            
        }

        public void ResolveEnemyEffect(CombatCard action, CharacterInstance target)
        {
            foreach (IEnemyEffect effect in action.GetEnemyEffects())
            {
                Debug.Log("Enemy attack processing");
                effect.ResolveEffect(action, target);
            }

            CombatBuffAndDebuffHelper(action, target);
        }
        
        void CombatBuffAndDebuffHelper(CombatCard card, CharacterInstance target)
        {
            foreach (DebuffSO effect in card.cardDebuffs)
            {
                if (card.IsAOE())
                {
                    if (card.validTargets[0] == CombatCard.CardTarget.AllPlayers || card.validTargets[0] == CombatCard.CardTarget.AllCharacters)
                    {
                        foreach (AllyInstance ally in CombatManager.Instance.Allies)
                        {
                            effect.CombatAddDebuff(card, ally);
                        }
                    }

                    if (card.validTargets[0] == CombatCard.CardTarget.AllEnemies || card.validTargets[0] == CombatCard.CardTarget.AllCharacters)
                    {
                        foreach (EnemyInstance enemy in CombatManager.Instance.Enemies)
                        {
                            effect.CombatAddDebuff(card, enemy);
                        }
                    }
                }
                else
                {
                    effect.CombatAddDebuff(card, target);
                }
            }

            foreach (BuffSO effect in card.cardBuffs)
            {
                if (card.IsAOE())
                {
                    if (card.validTargets[0] == CombatCard.CardTarget.AllPlayers || card.validTargets[0] == CombatCard.CardTarget.AllCharacters)
                    {
                        foreach (AllyInstance ally in CombatManager.Instance.Allies)
                        {
                            effect.CombatAddBuff(card, ally);
                        }
                    }

                    if (card.validTargets[0] == CombatCard.CardTarget.AllEnemies || card.validTargets[0] == CombatCard.CardTarget.AllCharacters)
                    {
                        foreach (EnemyInstance enemy in CombatManager.Instance.Enemies)
                        {
                            effect.CombatAddBuff(card, enemy);
                        }
                    }
                }
                else
                {
                    effect.CombatAddBuff(card, target);
                }
            }
        }
    } 
}
