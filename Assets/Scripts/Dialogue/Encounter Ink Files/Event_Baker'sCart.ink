EXTERNAL AlterCopRelations(int amount)
EXTERNAL AlterCivilianRelations(int amount)

-> main

=== main ===
A baker, transporting his goods by hand cart, has an unlucky break- that being one of his cart's wheels. As his bread spills over the road, a nearby policeman stops traffic to assist him.

+ [Get out and help the baker.]
    You hop out of the truck and quickly help the baker rein in his wayward grains, and the policeman notices you.
    // IF COP REPUTATION IS ABOVE 40:
    // "The officer thanks you for your help, and you go on your way."
    ~ AlterCopRelations(2)
    ~ AlterCivilianRelations(2)
    
    // ELSE:
    // "Looks like the cops are too familiar with your mugs. The policeman tells you to halt as you both prepare for a fight."
    // START A COMBAT ENCOUNTER WITH ONE COP
    
+ [Don't risk it; lay low.]
    You shrink down in the car, attempting to make yourself unrecognizable.
    // IF COP REPUTATION IS BELOW 25:
    // "Looks like the cops are too familiar with your mugs. The policeman tells you to halt as you both prepare for a fight."
    // START A COMBAT ENCOUNTER WITH ONE COP 
    
    // ELSE:
    // "You successfully slink away unnoticed."
    
+ [Not your problem. Get outta there!]
    You gun it, running over the baker's dozen or so loaves.
    ~ AlterCopRelations(-2)
    ~ AlterCivilianRelations(-4)

- -> END