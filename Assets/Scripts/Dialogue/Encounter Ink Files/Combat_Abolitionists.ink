EXTERNAL CheckPlayerPaneling()
EXTERNAL AddPaneling(int amount)
EXTERNAL AlterProhibitionistRelations(int amount)
EXTERNAL AlterCivilianRelations(int amount)

EXTERNAL StartCombat()

-> main

=== main ===
You weren't sure what it was from a distance, but as you closed the distance you sure found out. It was a mob of angry abolitionists, and now they've got you surrounded. A particularly beefy one yells through your window. "Right then! We know what you're doing. Come out and we'll settle this like men!"

+ [Oblige 'em.]
    ~ StartCombat()


~temp paneling = CheckPlayerPaneling()

{paneling >= 1}
+ [... You *are* in a big metal machine.]
    ~ AddPaneling(-1)
    ~ AlterProhibitionistRelations(-10)
    ~ AlterCivilianRelations(-3)
    You drive through the crowd, narrowly avoiding any major incidents. The abolitionists don't seem to like it one bit, and a lucky thrown shoe from one of them cracks your drivers' side window.
    
--> END