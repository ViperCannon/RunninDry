EXTERNAL AddCash(int amount)
EXTERNAL AlterCivilianRelations(int amount)
EXTERNAL FullPartyHeal(int amount)

-> main

=== main ===
Stopped at a red light, an enterprising young man in a red-and-white paper hat strolls up to your car. Knocking on a window, he proffers what seems to be a sausage on a long, thin bun. He clears his throat and speaks. "Get'cha fresh, delicious hot dogs! Good for what ails ya! Two bucks for three! Best dogs this side of the Park, no buts about it!" It does smell pretty good...

+ [Pay for the Decadent Dogs.]
   ~ AddCash(-2)
   ~ AlterCivilianRelations(3)
   ~ FullPartyHeal(5)
    You hand the man two bucks and in returns he hands you a paper tray with three frankfurters, still steaming from his cart. They're delicious.
 
+ [Roll up the window.]
    You're not hungry right now. You politely decline and roll up the window. The man moves on to the car behind you.
    
+ ["Presuade" him to donate his wares.]
    ~ AlterCivilianRelations(-5)
    ~ FullPartyHeal(3)
    You pull a gun on him and take his dog. He hightails it back to his cart and starts packing it up. As the light turns green, you take a bite. It tastes pretty good... the secret ingredient is crime.

- -> END