EXTERNAL StartCombat()

-> main

=== main ===
Okay, you know how I said there's some mean Mother Hubbards out for blood? Well, looks like some of 'em are heading straight towards you!

+ [Bring it... on?] -> Choice


=== Choice ===
Yes, yes, you can take a swing at 'em this time. But listen up first, 'cause you need t'know how to scrap in these parts.
  
+ [Please regale me, mysterious voice!] -> Tutorial

+ [I already know how.]
    A'ight, fine. You think know what you're doing? Go ahead. Skip my spiel. I'm not upset or anything. If you find you need a refresher, you can hover your mouse over certain icons to get some hints. Good luck.
    ~StartCombat()
    -> END
    
=== Tutorial ===
Click n' drag a card towards an enemy -that'd be the the goons to the right- to execute the card's effects on that enemy. However, usin' a card comes at a cost.
In the top right, ye'll see a belt 'o bullets. Those are yer caps, which ye only have a set amount of per turn! Each of yer cards has a number on it; that's its cap cost. 
Once you're out, you gotta end your turn using the button in the bottom right and take your lumps from whoever's standing opposite.
    Got all that?
    
+ [Yep.]
    Good, because here they come! If you need a refresher, you can hover your mouse over certain icons to get some hints! Now get to defending yourself!
    ~StartCombat()
    -> END
    
+ [Can you repeat all that?]
    Weren't listening, eh? You're lucky I'm patient. Let's go over this again.
    -> Tutorial