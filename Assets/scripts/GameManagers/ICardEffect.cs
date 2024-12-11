public interface ICardEffect
{
    void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target, CombatManager cManager);
    void ResolveEffect(NegotiationCardDisplay cardInstance, NegotiationManager nManager);
}
