EXTERNAL GetPlayerCash()
EXTERNAL AddPaneling(int amount)
EXTERNAL AddTires(int amount)
EXTERNAL FullPartyHeal(int amount)
EXTERNAL AddCash(int amount)

VAR cash = 0

-> main

=== main ===
~GetPlayerCash()
You pull off to a small shopping strip and decide you have time to make one purchase.

+ {cash >= 3} [Grab some grub. (-$3)]
    The crew is looking in healthier spirits afdter the lunch break! (+15 HP to all party members!)
    ~ AddCash(-3)
    ~ FullPartyHeal(15)

+ {cash >= 4} [Get a spare tire. (-$4)]
    You were able to find a spare for fairly cheap! Lucky you! (Obtained 1 Tire.)
    ~ AddCash(-4)
    ~ AddTires(1)

+ {cash >= 5} [Get a quick service job. (-$5)]
    The service agent obliges to a speedy repair... after a little convincing. (Obtained 1 Paneling.)
    ~ AddCash(-5)
    ~ AddPaneling(1)
    
+ [Hit the Road.]

--> END