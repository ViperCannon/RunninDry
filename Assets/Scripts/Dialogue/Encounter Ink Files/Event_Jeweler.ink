EXTERNAL AddCash(int amount)
EXTERNAL AlterCopRelations(int amount)
EXTERNAL AlterCivilianRelations(int amount)

-> main

=== main ===
A dejected-looking man in a grey suit sits on a bench, just outside Barnaby's, a major jewelry store. He's all but crying into his hands. You see an opportunity here.

+ [Drive up and ask what's wrong.] -> continue

=== continue ===

The man looks up at you, weighing his options, then speaks. "I... my girl, she had her heart set on this one ring. Real thing a' beauty, but way outta my price range. The clerk I was talkin' to says he can cut me a deal, hold it for me while I pay off it in installments...." The man trails off, then shakes himself slightly. "That was eight months ago. I finally saved up enough to get it, but the damn crook raised the price on me, and now he's threatenin' to sell it if I don't come back with more!" His voice begins to tremble. "I... i was gonna propose to her with that ring... but now..." 

+ [Offer to "have a talk" with the crooked clerk.]
    ~ AddCash(10)
    ~ AlterCopRelations(-5)
    ~ AlterCivilianRelations(5)
    You discreetly show off your weapon and offer to make the clerk reconsider. Ten minutes later, you and the man are standing outside the store, the man beaming with the ring in his hands. The nice clerk even deigned to give the man a discount, which he graciously gave back to you!
 
+ [Convince him he doesn't need a ring to show his affection.]
    If she truly loves him, she doesn't need any stinking ring! But if he's deadset on one, he could try a jeweler in Little Italy that could cut him a deal- a jeweler who may or may not be your cousin...
    // NEGOTIATION: P/I/B 10/16/18
        // ON SUCCESS:
            // ~ AddCash(15)
            // ~ AlterCivilianRelations(3)
            // "The man thanks you for your advice and provides you with a parting gift before darting off."
        // ON FAIL:
            // ~ AlterCivilianRelations(1)
            // "The man thanks you for your kindness, but politely declines your offer."

- -> END