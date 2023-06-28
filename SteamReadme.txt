[h1]Show Food Availability[/h1]

Displays one or more additional food counters which do not include food placed on a Food Producer.

These counters indicate if the food on Food Producers will need to be used to feed villagers.

A Food Producer is a garden, farm, fishing trap, etc.

[h1]Display Options[/h1]
The food count can be &quot;Food not the first item on a Food Producer&quot; and/or &quot;Food that is not part of a stack on a Food Producer&quot;.

By default, only the &quot;Not in stack&quot; value is added to the display, and the food text will change to orange if any enabled food counters is under the required food.

See [url=#settings]Settings[/url] below.

The first 5 items on a Composter are excluded from both counts.

[h2]Example[/h2]
Given a board where there is only three Raw Fish as food and they are all on a Fish Trap, the counters would show as follows:

Display in game<br />
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
[h2]2.0[/h2]
Steam Workshop compatibility.
