EXTERNAL GetPlayerCash()
EXTERNAL AddCash(int amount)
EXTERNAL AlterCivilianRelations(int amount)

VAR cash = 0

-> main

=== main ===
GetPlayerCash()
A small orange and white cat runs into the road, followed closely by a young girl. The car has to swerve to a stop to avoid hitting her.

+ [Tell her off.]
    ~ AlterCivilianRelations(-5)
    The girl scoops up the cat and runs off crying, noticed by a few passersby.
 
+ [Continue on your way.]
    The cat and girl wander off the road and you continue onwards.
    
+ {cash >= 1} [Give her something to keep her off the road.]
    ~ AddCash(-1)
    ~ AlterCivilianRelations(3)
    You toss her a dollar and tell her to get a candy from the market. She takes it, beaming, and hurries off, the cat following close behind her.

- -> END