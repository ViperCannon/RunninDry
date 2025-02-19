EXTERNAL AddCash(int amount)
EXTERNAL AlterCivilianRelations(int amount)

-> main

=== main ===
An elderly woman waits on the street corner, attempting to cross the fairly busy intersection.

+ [Stop to help her across.]
    The woman sees you approach.
    // IF CIVILIAN REPUTATION IS BELOW 25:
        // ~ AlterCivilianRelations(-2)
        // "At the sight of you, she frowns turns away to find another crosswalk."
        
    // ELSE IF CIVILIAN REPUTATION IS BETWEEN 25 AND 60:
        // ~ AlterCivilianRelations(2)
        // "She thanks you as you help her across."
        
    // ELSE:
        // ~ AddCash(3)
        // ~ AlterCivilianRelations(2)
        // "She thanks you as you help her across. Once you reach the other side, she presses a few bills into your hands."
 
+ [Ignore her and continue on.]
    You have something more important to worry about. You continue on your way, the woman disappearing in your rearview mirror.

- -> END