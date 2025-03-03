EXTERNAL AddPaneling(int amount)

EXTERNAL StartCombat()

EXTERNAL StartNegotiation(int d, int i, int b)

VAR negotiationSuccess = false

-> main

=== main ===
As you stop at an intersection, you feel a slight bump and hear a clang of metal. Looking out the window, some ignoramus didn't stop in time and rear ended you! Irate, the man and his passenger jump out of his automobile, demanding your name and compensation... was this on purpose?

+ [Defuse the situation.]
    ~ StartNegotiation(14, 8, 10)
    Negotiation time!
    { negotiationSuccess :
    - true: -> success
    - false: -> failure
    }
    
+ [Give him something to REALLY complain about.]
    As you get out of your car and draw your weapons, the man pauses then launches himself at you.
    ~ StartCombat()
    -> END
    
    === success ===
    The man cools off, apologizes, and returns to his vehicle. -> END
    
    === failure === 
    ~ AddPaneling(-1)
    Your words only piss him off further, and he elbows one of your car windows in. -> END