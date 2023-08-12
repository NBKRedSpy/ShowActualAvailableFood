# Show Food Availability

Adds additional food counters which indicate how much food is freely available.  Specifically, food that is not being used by a "Food Processor" such as a campfire or garden.

This mod can also change the "low food" blink to use a multiplier.  For example, start blinking when there is less than 2x the required food.  This can be enabled in the settings.

# Display Options
The following counters can be enabled:
* Total food in all hot pots.
* Food that is not the first item on a Food Processor
* (Default) Food that is not stacked on Food Processor.

See [Settings](#settings) below.

The first five items on a Composter are excluded from both counts.


## Example

![Counters Example](https://raw.githubusercontent.com/NBKRedSpy/ShowActualAvailableFood/master/media/Example%20Diagram.png)

# Settings

|Setting|Default|Description|
|--|--|--|
|ShowNotFirstFood|Off|Shows the amount of food that is not the first card on a food processor.  The first five items on a Composter are also excluded from this count.|
|ShowNotInStack|On|Shows the amount of food that is not on a food processor at all.|
|Show Hotpot|Off|Shows the total amount of food in hotpots|
|ShowWarningColor|true|If true, the food text will be changed to an orange color if one of the enabled food counters are below the required food.|
|WarningMultiplier|1|The food warning multiplier.  For example, if the value is 2, the minimum food warning will be shown if the food is less than 2x the required food |

# Change Log
## 2.2.0

Added optional hotpot counter.
Thank you to jmucchiello for the suggestion.

## 2.1.0
Added all known food producers and processors.

Thank you to jmucchiello for reporting the missing items issue.

Warning - Card spoiler ahead

[spoiler]
 
 * Garden
 * FishTrap 
 * Greenhouse 
 * Poop
 * Composter
 * Hotpot
 * Tavern
 * Distillery 
 * Oven
 * Soil
 * Campfire
 * Stove

 [/spoiler]



## 2.0.0
Steam Workshop compatibility.
