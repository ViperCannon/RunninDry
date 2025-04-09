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

                foreach (IBuffEffect effect in card.cardData.GetBuffEffects())
                {
                    if (card.cardData.IsAOE())
                    {
                        if (card.cardData.validTargets[0] == CombatCard.CardTarget.AllPlayers || card.cardData.validTargets[0] == CombatCard.CardTarget.AllCharacters)
                        {
                            foreach (AllyInstance ally in CombatManager.Instance.Allies)
                            {
                                effect.ResolveEffect(card, ally);
                            }
                        }
                        
                        if (card.cardData.validTargets[0] == CombatCard.CardTarget.AllEnemies || card.cardData.validTargets[0] == CombatCard.CardTarget.AllCharacters)
                        {
                            foreach (EnemyInstance enemy in CombatManager.Instance.Enemies)
                            {
                                effect.ResolveEffect(card, enemy);
                            }
                        }
                    }
                    else
                    {
                        effect.ResolveEffect(card, target);
                    }      
                }
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

                foreach (IBuffEffect effect in card.cardData.GetBuffEffects())
                {
                    effect.ResolveEffect(card);
                }
            }

            
        }

        public void ResolveEnemyEffect(CombatCard action, CharacterInstance target)
        {
            foreach (IEnemyEffect effect in action.GetEnemyEffects())
            {
                Debug.Log("Enemy attack processing");
                effect.ResolveEffect(action, target);
            }

            foreach (IBuffEffect effect in action.GetBuffEffects())
            {
                if (action.IsAOE())
                {
                    if (action.validTargets[0] == CombatCard.CardTarget.AllPlayers  || action.validTargets[0] == CombatCard.CardTarget.AllCharacters)
                    {
                        foreach (AllyInstance ally in CombatManager.Instance.Allies)
                        {
                            effect.ResolveEffect(action, ally);
                        }
                    }
                    
                    if (action.validTargets[0] == CombatCard.CardTarget.AllEnemies || action.validTargets[0] == CombatCard.CardTarget.AllCharacters)
                    {
                        foreach (EnemyInstance enemy in CombatManager.Instance.Enemies)
                        {
                            effect.ResolveEffect(action, enemy);
                        }
                    }
                }
                else
                {
                    effect.ResolveEffect(action, target);
                }
                    
            }
        }
    }
}
