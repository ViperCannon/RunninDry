EXTERNAL GetPlayerCash()
EXTERNAL DisableChoiceButton(int choice)
EXTERNAL AddCash(int amount)
EXTERNAL AddTires(int amount)
EXTERNAL AddPaneling(int amount)
EXTERNAL AlterCivilianRelations(int amount)

EXTERNAL StartCombat()
EXTERNAL StartNegotiation(int d, int i, int b)
EXTERNAL FullPartyHeal(int amount)

VAR negotiationSuccess = false
VAR cash = 0

-> main

=== main ===
~ GetPlayerCash()
{cash < 10:
~ DisableChoiceButton(0)
} 
You pull into a gas station looking to refuel while patching up the car and grabing a bite to eat. As the attendant is fueling up the car you notice he looks a bit... green. Perhaps you could use this to your advantage?

+ [Just pay for your snacks. (-$10)]
    ~ AddCash(-10)
    ~ FullPartyHeal(5)
    ~ AddTires(1)
    ~ AddPaneling(1)
    ~ AlterCivilianRelations(2)
    Deciding it's not worth the risk, you simply pay the man and give him a decent tip. -> END
 
+ [Persuade him for a freebie.]
    ~ StartNegotiation(11, 8, 13)
    Negotiation time!
    { negotiationSuccess :
    - true: -> success
    - false: -> failure
    }
    
+ [Dine and Dash. What're they gonna do, stop you?]
    ~ AlterCivilianRelations(-5)
    ~ AddTires(1)
    ~ AddPaneling(1)
    Before the attendant finished his work, you're outta there. You didn't get your snacks, but not a huge loss. -> END

=== success ===
~ AlterCivilianRelations(-3)
~ AddTires(1)
~ AddPaneling(1)
~ FullPartyHeal(5)
The young attendant simply balks and lets you go. -> END
    
=== failure ===
~ AlterCivilianRelations(-3)
The attendant calls out for help, and three nearby policemen move in to support him.
~ StartCombat()
-> END