# Show Food Availability
![Food Icon](Thunderstore.io/icon.png)

Displays one or more additional food counters which do not include food placed on a Food Producer.

These additional counters indicate if the food on Food Producers will need to be used to feed villagers.

A Food Producer is a garden, farm, fishing trap, etc.

# Display Options

The food count can be "Food not the first item on a Food Producer" and/or "Food that is not part of a stack on a Food Producer".

By default, only the "Not in stack" value is added to the display.

See [Settings](#settings) below.

The first 5 items on a Composter are excluded from both counts.

## Example

Given a board where there is only three Raw Fish as food and they are all on a Fish Trap, the counters would show as follows:

Display in game
0/2/3/999

|Counter|Value|Is regular game counter|
|--|--|--|
|Not in stack|0||
|Not first item on stack|2||
|Game's total Food|3|true|
|Food required to feed the Villagers (vanilla counter)|999|true|

# Settings

|Setting|Default|Description|
|--|--|--|
|ShowNotFirstFood|false|Shows the amount of food that is not the first card on a food consumer.  The first five items on a Composter are also excluded from this count.|
|ShowNotInStack|true|Shows the amount of food that is not on a food consumer at all.|

