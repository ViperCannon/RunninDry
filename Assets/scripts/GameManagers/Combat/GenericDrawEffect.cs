using UnityEngine;

[CreateAssetMenu(fileName = "New GenericDrawEffect", menuName = "GenericDrawEffect")]
public class GenericDrawEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        if (cardInstance.cardData.subTypes.Contains(CombatCard.CombatSubType.Unload)) //unload (X-cost) cards
        {
            cManager.handManager.AttemptDraw(cardInstance.unload);
        }
        else //draw specified by card
        {
            cManager.handManager.AttemptDraw(cardInstance.cardData.drawAmount);
        }
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance, NegotiationManager nManager)
    {
        nManager.handManager.AttemptDraw(cardInstance.cardData.drawAmount);
    }
}
