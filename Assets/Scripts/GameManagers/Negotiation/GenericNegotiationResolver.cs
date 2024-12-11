using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNegotiationResolver : ICardEffect
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

        switch (((int)cardInstance.cardData.subTypes[0]))
        {
            case 0:

                if(result == numOfDice * sidedDice)
                {
                    //resolve crit effects



                }
                else
                {

                }

                break;

            case 1:

                if (result == numOfDice * sidedDice)
                {
                    //resolve crit effects



                }
                else
                {

                }

                break;

            case 2:

                if (result == numOfDice * sidedDice)
                {
                    //resolve crit effects



                }
                else
                {

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
