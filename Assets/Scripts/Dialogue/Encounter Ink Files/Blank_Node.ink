VAR random = 0
-> main

=== main ===
~ random = RANDOM(1,4)

{ random: 
    - 1: -> Scenario1
    - 2: -> Scenario2
    - 3: -> Scenario3
    - 4: -> Scenario4
}

=== Scenario1 ===

Usually, this part of the city would be busy at this hour, but you seem to be in luck; it's all but deserted.

+ [Might as well enjoy the downtime.] -> END

=== Scenario2 ===

It's quiet. ... Too quiet.
Despite this, nothing jumps out at you or causes any sort of fuss. Maybe it's best you leave before something decides to.

+ [Agreed. Time to go.] -> END

=== Scenario3 ===

This block seems particularly empty at the moment. All you hear as you round the corner is the thrum of the car's engine.

+ [Music to my ears.] -> END

=== Scenario4 ===

In the placid silence of this isolated street, you can almost forget that you're wanted criminals smuggling illegal goods. Almost.

+ [Onward! To more crime!] -> END