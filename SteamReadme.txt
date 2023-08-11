[h1]Show Food Availability[/h1]

Adds additional food counters which indicate how much food is freely available.  Specifically, food that is not being used by a "Food Processor" such as a campfire or garden.

This mod can also change the "low food" blink to use a multiplier.  For example, start blinking when there is less than 2x the required food.  This can be enabled in the settings.

[h1]Display Options[/h1]

The food counts can be "Food that is not the first item on a Food Processor" and/or "Food that is not stacked on Food Processor".

By default, only the "Not in stack" value is added to the display, and the food text will change to orange if any enabled food counters is under the required food.

See [url=#settings]Settings[/url] below.

The first five items on a Composter are excluded from both counts.

[h2]Example[/h2]

Given a board where there is only three Raw Fish as food and they are all on a Fish Trap, the counters would show as follows:

Display in game
0/2/3/999
[table]
[tr]
[td]Counter
[/td]
[td]Value
[/td]
[td]Is regular game counter
[/td]
[/tr]
[tr]
[td]Not in stack
[/td]
[td]0
[/td]
[td]
[/td]
[/tr]
[tr]
[td]Not first item on stack
[/td]
[td]2
[/td]
[td]
[/td]
[/tr]
[tr]
[td]Game's total Food
[/td]
[td]3
[/td]
[td]true
[/td]
[/tr]
[tr]
[td]Food required to feed the Villagers
[/td]
[td]999
[/td]
[td]true
[/td]
[/tr]
[/table]

[h1]Settings[/h1]
[table]
[tr]
[td]Setting
[/td]
[td]Default
[/td]
[td]Description
[/td]
[/tr]
[tr]
[td]ShowNotFirstFood
[/td]
[td]false
[/td]
[td]Shows the amount of food that is not the first card on a food consumer.  The first five items on a Composter are also excluded from this count.
[/td]
[/tr]
[tr]
[td]ShowNotInStack
[/td]
[td]true
[/td]
[td]Shows the amount of food that is not on a food consumer at all.
[/td]
[/tr]
[tr]
[td]ShowWarningColor
[/td]
[td]true
[/td]
[td]If true, the food text will be changed to an orange color if one of the enabled food counters are below the required food.
[/td]
[/tr]
[tr]
[td]WarningMultiplier
[/td]
[td]1
[/td]
[td]The food warning multiplier.  For example, if the value is 2, the minimum food warning will be shown if the food is less than 2x the required food
[/td]
[/tr]
[/table]

[h1]Change Log[/h1]

[h2]2.1.0[/h2]

Added all known food producers and processors.

Thank you to jmucchiello for reporting the missing items issue.

Warning - Card spoiler ahead

[spoiler]
[list]
[*]Garden
[*]FishTrap
[*]Greenhouse
[*]Poop
[*]Composter
[*]Hotpot
[*]Tavern
[*]Distillery
[*]Oven
[*]Soil
[*]Campfire
[*]Stove
[/list]

[/spoiler]

[h2]2.0.0[/h2]

Steam Workshop compatibility.
