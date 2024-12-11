using UnityEngine;

[CreateAssetMenu(fileName = "New GenericNegotiationEffect", menuName = "GenericNegotiationEffect")]
public class GenericNegotiationResolver : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {

    }
    public void ResolveEffect(NegotiationCardDisplay cardInstance, NegotiationManager nManager)
    {
        int numOfDice = cardInstance.cardData.numberOfDice;
        int sidedDice = cardInstance.cardData.sidedDice;
        int modifier = cardInstance.cardData.diceModifier;

        int result = RollDice(numOfDice, sidedDice);

        Debug.Log("negot");

        switch (((int)cardInstance.cardData.subTypes[0]))
        {
            case 0:

                if(result == numOfDice * sidedDice)
                {
                    //resolve crit effects

                    nManager.Success();
                    nManager.EndNegotiation();

                }
                else
                {
                    if(result + modifier > 12)
                    {
                        nManager.Success();
                        nManager.EndNegotiation();
                    }
                    else
                    {
                        nManager.Fail();
                        nManager.EndNegotiation();
                    }
                }

                break;

            case 1:

                if (result == numOfDice * sidedDice)
                {
                    //resolve crit effects

                    nManager.Success();
                    nManager.EndNegotiation();

                }
                else
                {
                    if (result + modifier > 12)
                    {
                        nManager.Success();
                        nManager.EndNegotiation();
                    }
                    else
                    {
                        nManager.Fail();
                        nManager.EndNegotiation();
                    }
                }

                break;

            case 2:

                if (result == numOfDice * sidedDice)
                {
                    //resolve crit effects

                    nManager.Success();
                    nManager.EndNegotiation();

                }
                else
                {
                    if (result + modifier > 12)
                    {
                        nManager.Success();
                        nManager.EndNegotiation();
                    }
                    else
                    {
                        nManager.Fail();
                        nManager.EndNegotiation();
                    }
                }

                break;
        }

    }

    private int RollDice(int numOfDice, int sides)
    {
        int result = 0;

        for(int i = 0; i < numOfDice; i++)
        {
            result += Random.Range(1, sides + 1);
        }

        return result;
    }
}
