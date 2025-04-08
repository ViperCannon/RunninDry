EXTERNAL StartCombat()

-> main

=== main ===
Okie, ye know how I said there's some mean Mother Hubbards out fer blood? Well, these'd be some of 'em!

+ [Bring it... on?] -> Choice


=== Choice ===
Yes, yes, ye can take a swing at 'em this time. But listen up first, 'cause ye need t'know how to scrap in these parts.
  
+ [Please regale me, mysterious voice!] -> Tutorial

+ [I already know how.]
    A'ight, fine. Ye think know what ye're doing? Go ahead. Skip my spiel. I'm not upset or anything. Either way, good luck.
    ~StartCombat()
    -> END
    
=== Tutorial ===
Click n' drag a card towards an enemy to spend that many caps and execute the card's effects on that enemy. Each of yer cards has a number on it; that's its cap cost. In the top right, ye'll see a belt 'o bullets. Those are yer caps, which ye only have a set amount of per turn! Once yer out, ye gotta end yer turn and take yer lumps from whoever's standing opposite ye.
    Got that? 
    
+ [Yep.]
    Good, because here they come!
    ~StartCombat()
    -> END
    
+ [Can you repeat all that?]
    Weren't listening, eh? Ye're lucky I'm patient. Let's go over this again.
    -> Tutorial