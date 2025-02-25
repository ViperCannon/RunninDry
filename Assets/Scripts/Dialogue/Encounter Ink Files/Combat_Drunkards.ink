EXTERNAL AddBooze(int amount)
EXTERNAL AlterDrunkardRelations(int amount)
EXTERNAL AlterCivilianRelations(int amount)

EXTERNAL StartCombat()

-> main

=== main ===
A group of disheveled looking men and women approach your car. Their clothes are worn and sweaty, and a few of them carry knives and improvised clubs. They do not appear to be having a good time. One of them speaks up. "Oi! We know youse gots the good stuff! We ain't had nothin since our pub closed down- give us some, or else!" How could they know? Are they bluffing?

+ [Sock it to 'em!]
    ~ AlterDrunkardRelations(-5)
    They don't look so tough. You can take them.
    ~ StartCombat()
 
+ [Give them a bottle.]
    ~ AddBooze(-1)
    ~ AlterDrunkardRelations(10)
    ~ AlterCivilianRelations(5)
    Might as well not attract too much attention.
    
--> END