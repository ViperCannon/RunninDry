EXTERNAL AddCash(int amount)
EXTERNAL AddTires(int amount)
EXTERNAL AddPaneling(int amount)
EXTERNAL AlterCivilianRelations(int amount)
EXTERNAL FullPartyHeal(int amount)

-> main

=== main ===
You pull into a gas station looking to refuel while patching up the car and grabing a bite to eat. As the attendant is fueling up the car you notice he looks a bit... green. Perhaps you could use this to your advantage?

+ [Just pay for your snacks.]
    ~ AddCash(-15)
    // ~Add Tires(1) OR ~AddPaneling(1)
    ~ AlterCivilianRelations(2)
    Deciding it's not worth the risk, you simply pay the man and give him a decent tip.
 
+ [Persuade him for a freebie.]
    // NEGOTIATION: P/I/B 11/8/13
        // ON SUCCESS:
            // AlterCivilianRelations(-3)
            // FullPartyHeal(5)
            // "The young attendant balks and lets you go."
        // ON FAIL:
            // ~ AlterCivilianRelations(-3)
            // "The attendant calls out for help, and three nearby policemen move in to support him."
            // BEGIN COMBAT ENCOUNTER WITH THREE COPS
    This is the message for outcome 2.
    
+ [Dine and Dash. What're they gonna do, stop you?]
    // AlterCivilianRelations(-5)
    // ~Add Tires(1) OR ~AddPaneling(1)
    Before the attendant finished his work, you're outta there. You didn't get your snacks, but not a huge loss.

- -> END