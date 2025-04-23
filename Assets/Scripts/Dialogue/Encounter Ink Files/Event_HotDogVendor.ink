EXTERNAL GetPlayerCash()
EXTERNAL DisableChoiceButton(int choice)
EXTERNAL AddCash(int amount)
EXTERNAL AlterCivilianRelations(int amount)
EXTERNAL FullPartyHeal(int amount)

VAR cash = 0

-> main

=== main ===
~ GetPlayerCash()

Stopped at a red light, an enterprising young man in a red-and-white paper hat strolls up to your car and knocks on a window.

+  [Roll down the window.] -> choice

+  [Not interested.]
    You decide not to indulge him. You wave him off as he dejectedly moves on to the car behind you.
    -> END

=== choice ===
{cash < 2:
~ DisableChoiceButton(0)
}
He clears his throat and speaks. "Get'cha fresh, delicious hot dogs! Good for what ails ya! Two bucks for three! Best dogs this side of the Park, no buts about it!" It does smell pretty good...

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