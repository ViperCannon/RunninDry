public interface ICardEffect
{
    void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target);
    void ResolveEffect(NegotiationCardDisplay cardInstance);
}
