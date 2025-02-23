EXTERNAL AddPaneling(int amount)

-> main

=== main ===
As you stop at an intersection, you feel a slight bump and hear a clang of metal. Looking out the window, some ignoramus didn't stop in time and rear ended you! Irate, the man and his passenger jumps out of his automobile, demanding your name and compensation... was this on purpose?

+ [Defuse the situation.]
    // NEGOTIATION: P/I/B 14/8/10
        // ON SUCCESS:
            // "The man cools off, apologizes, and returns ot his vehicle."
        // ON FAIL:
            // ~ AddPaneling(-1)
            // "Your words only piss him off further, and he elbows one of yoru car windows in."
 
+ [Give him something to REALLY complain about.]
    As you get out of your car and draw your weapons, the man pauses then launches himself at you.
    // START A COMBAT ENCOUNTER WITH TWO CIVILIANS AND TWO DRUNKS

- -> END