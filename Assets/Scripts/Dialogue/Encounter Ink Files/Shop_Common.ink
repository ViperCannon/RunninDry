EXTERNAL AddPaneling(int amount)
EXTERNAL AddTires(int amount)
EXTERNAL FullPartyHeal(int amount)
EXTERNAL AddCash(int amount)

-> main

=== main ===
You pull off to a small shopping strip anbd decide you got time to make one purchase.

+ [Grab some grub (3 cash)]
    The crew is looking in healthier spirits afdter the lunch break! (healed each member by 10)
    ~ AddCash(-3)
    ~ FullPartyHeal(15)

+ [Get a spare tire (4 cash)]
    You were able to find a spare for fairly cheap! (Obtained 1 tire)
    ~ AddCash(-4)
    ~ AddTires(1)

+ [Get a quick service job (5 cash)]
    The service agent obliged to a speedy repair after a little convincing. (Obtained 1 panelling)
    ~ AddCash(-5)
    ~ AddPaneling(1)
    
+ [Hit the road]

--> END