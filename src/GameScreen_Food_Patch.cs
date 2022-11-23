using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;

namespace ShowActualAvailableFood
{

    [HarmonyPatch(typeof(GameScreen), "Update")]
    public static class GameScreen_Food_Patch
    {

        private static Color WarningColor;


        public static void Postfix(GameScreen __instance)
        {


            if(Plugin.ShowNotFirstFood.Value == false && Plugin.ShowNotInStack.Value == false)
            {
                //Not sure why this mod is even enabled ;)
                return;
            }

            FoodCount count = GetFoodPlacementCount(__instance);


            int totalFoodCount = WorldManager.instance.GetFoodCount(false);



            List<string> countStrings = new List<string>();

            int notInStackFoodRemainder = totalFoodCount - count.OnProduerStack;
            int notFirstFoodRemainder = totalFoodCount - count.FirstOnProducer;

            if (Plugin.ShowNotInStack.Value)
            {
                countStrings.Add(notInStackFoodRemainder.ToString());
            }

            if(Plugin.ShowNotFirstFood.Value)
            {
                countStrings.Add(notFirstFoodRemainder.ToString());
            }

            __instance.FoodText.text = $"{string.Join("/", countStrings)}/{__instance.FoodText.text}";

            //---Set warning color
            if (Plugin.ShowWarningColor.Value)
            {
                int requiredfoodCount = WorldManager.instance.GetRequiredFoodCount();

                if ((totalFoodCount >= requiredfoodCount && WorldManager.instance.DebugNoFoodEnabled == false) && (
                    (Plugin.ShowNotInStack.Value && notInStackFoodRemainder < requiredfoodCount) ||
                    (Plugin.ShowNotFirstFood.Value && notFirstFoodRemainder < requiredfoodCount)
                    ))
                {
                    //Tried creating a color, but oddly the text would be red, and the icon would be the selected color.
                    //  Using an existing color like Color.blue or one from the ColorManager.instance worked fine.
                    //  Maybe the color has to be created in a specific way and "new Color" doesn't work?
                    __instance.FoodText.color = ColorManager.instance.BuildingCard;
                }
            }
        }

        internal static FoodCount GetFoodPlacementCount(GameScreen gameScreen)
        {

            FoodCount totalFoodCount = new FoodCount();

            foreach (GameCard gameCard in WorldManager.instance.AllCards)
            {

                if (gameCard.MyBoard.IsCurrent && IsFoodProducer(gameCard))
                {

                    bool isComposter = gameCard.CardData is Composter;
                    GameCard childGameCard;
                    childGameCard = gameCard.Child;
                    int depth = 0;

                    //Loop through the stack of the producer and count the cards.
                    while(childGameCard != null)
                    {
                        //There shouldn't be anything but food, but just in case, verify.
                        if(childGameCard.CardData != null && childGameCard.CardData is Food)
                        {
                            int foodCount = ((Food)childGameCard.CardData).FoodValue;

                            //Composter internally consumes the first 5 cards.
                            if(depth == 0 || (isComposter && depth < 5 ))
                            {
                                totalFoodCount.FirstOnProducer += foodCount;
                            }

                            totalFoodCount.OnProduerStack += foodCount;
                        }

                        childGameCard = childGameCard.Child;
                        depth++;
                    }
                }
            }

            return totalFoodCount;
        }

        public static bool IsFoodProducer(GameCard gameCard)
        {
            if (gameCard == null) return false;

            CardData cardData = gameCard.CardData;
            return
                cardData is Garden ||
                cardData is FishingSpot ||
                cardData is FishTrap ||
                cardData is Greenhouse ||
                cardData is Poop ||
                cardData is Composter ||
                cardData.Id == "soil";      //Soil is a created card.

        }


    }

    internal record struct FoodCount(int FirstOnProducer, int OnProduerStack);
}
