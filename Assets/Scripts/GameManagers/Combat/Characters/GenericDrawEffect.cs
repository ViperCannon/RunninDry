using UnityEngine;

[CreateAssetMenu(fileName = "New GenericDrawEffect", menuName = "GenericDrawEffect")]
public class GenericDrawEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target)
    {
        if (cardInstance.cardData.subTypes.Contains(CombatCard.CombatSubType.Unload)) //unload (X-cost) cards
        {
            CombatManager.Instance.handManager.AttemptDraw(cardInstance.unload);
        }
        else //draw specified by card
        {
            CombatManager.Instance.handManager.AttemptDraw(cardInstance.cardData.drawAmount);
        }
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance)
    {
        NegotiationManager.Instance.handManager.AttemptDraw(cardInstance.cardData.drawAmount);
    }
}
