using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeakeasyStreet
{
    public class CardEffectResolver : MonoBehaviour
    {
        CombatManager cManager;
        NegotiationManager nManager;

        void Start()
        {
            cManager = GetComponent<CombatManager>();
            nManager = GetComponent<NegotiationManager>();
        }

        public void ResolveCardEffects(CardDisplay cardInstance, CharacterInstance target)
        {
            if(cardInstance is CombatCardDisplay)
            {
                CombatCardDisplay card = (CombatCardDisplay)cardInstance;

                foreach (ICardEffect effect in card.cardData.GetCardEffects())
                {
                    effect.ResolveEffect(card, target, cManager);
                }
            }
            else
            {
                
                NegotiationCardDisplay card = (NegotiationCardDisplay)cardInstance;

                Debug.Log(card.cardData.GetCardEffects().Count);

                

                foreach (ICardEffect effect in card.cardData.GetCardEffects())
                {
                    Debug.Log("resolving");
                    effect.ResolveEffect(card, nManager);
                }
            }

            
        }
    }
}
