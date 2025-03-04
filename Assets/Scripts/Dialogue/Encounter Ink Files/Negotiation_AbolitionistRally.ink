EXTERNAL AddCash(int amount)

EXTERNAL AlterCopRelations(int amount)
EXTERNAL AlterProhibitionistRelations(int amount)
EXTERNAL AlterDrunkardRelations(int amount)
EXTERNAL AlterCivilianRelations(int amount)

EXTERNAL StartCombat()
EXTERNAL StartNegotiation(int d, int i, int b)

VAR negotiationSuccess = false

-> main

=== main ===
As you continue down the street, you notice a crowd gathering at a small park. As you drive closer, you see it appears to be some sort of abolitionist rally, with a stage and everything. The speaker is impassioned, but the crowd seems... reluctant. Perhaps this is a good opportunity to speak your mind...

+ [Speak on behalf of the people.]
    You take to the podium, espousing how the Inhibition Act robs the people of Flatiron City- and the United Territories- of their freedoms. The crowd murmurs...
    ~ StartNegotiation(14, 20, 13)
    Negotiation time!
    { negotiationSuccess :
    - true: -> success
    - false: -> failure
    }
 
+ [Go after the abolitionists!]
    You start vehemently attacking the opposing speaker and their allies, criticizing their appearance, superficial morals, prudishness and cold demeanor. The crowd murmurs...
    ~ StartNegotiation(18, 12, 15)
    Negotiation time!
    { negotiationSuccess :
    - true: -> success
    - false: -> failure
    }
    
+ [Cause some "mayhem."]
~ AddCash(25)
~ AlterCopRelations(-10)
~ AlterProhibitionistRelations(-10)
~ AlterCivilianRelations(-5)
You get on stage and pull out your weapon, firing into the air. The organized crowd becomes a mob in seconds, some scrambling to get away, others moving to intercept you. In the chaos, you're able to grab a few purses! (+25 Cash) -> END
    
=== success ===
~ AlterProhibitionistRelations(-8)
~ AlterDrunkardRelations(8)
~ AlterCivilianRelations(5)
The crowd hears your words and begins to chant "Booze! Booze! Booze!" The abolitionists hightail it out of there. -> END
    
=== failure ===
~ AlterProhibitionistRelations(-5)
~ AlterDrunkardRelations(3)
~ AlterCivilianRelations(-3)
The crowd becomes restless, opinion turning on you. The Abolitionist speaker smiles then yells "Get 'em!"
~ StartCombat()
-> END