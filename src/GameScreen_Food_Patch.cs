﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShowActualAvailableFood
{

    [HarmonyPatch(typeof(GameScreen), "Update")]
    public static class GameScreen_Food_Patch
    {
        public static void Postfix(GameScreen __instance)
        {

            if(Plugin.ShowNotFirstFood.Value == false && Plugin.ShowNotInStack.Value == false)
            {
                //Not sure why this mod is even enabled ;)
                return;
            }

            FoodCount count = GetFoodPlacementCount(__instance);

            int totalFoodCount;
            totalFoodCount = WorldManager.instance.GetFoodCount(false);

            List<string> countStrings = new List<string>();
            
            if(Plugin.ShowNotInStack.Value)
            {
                countStrings.Add((totalFoodCount - count.OnProduerStack).ToString());
            }

            if(Plugin.ShowNotFirstFood.Value)
            {
                countStrings.Add((totalFoodCount - count.FirstOnProducer).ToString());
            }

            __instance.FoodText.text = $"{string.Join("/", countStrings)}/{__instance.FoodText.text}";
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


        /// <summary>
        /// Loop through all of the food parents to see if they end on a food producer.
        /// </summary>
        /// <param name="gameCard"></param>
        /// <returns>hasAncestor means the food has a food producer as a parent in a stack
        /// isDirectPlacement means the food is the food that is currently being processed by a stack.
        /// </returns>
        //private static FoodPlacement IsAncestorFoodProducer(GameCard gameCard)
        //{


        //    //Finish Here - change the count to be from parent on.  
        //    //  Should be a lot less data traversal.

        //    FoodPlacement producerInfo = new FoodPlacement(false, false);

        //    if (gameCard == null || gameCard.Parent == null) return producerInfo;

        //    GameCard targetCard = gameCard.Parent;

        //    int depth = 0;

        //    while(targetCard != null)
        //    {
        //        if(targetCard.CardData is Composter)
        //        {
        //            //The composter requires 5 cards to start.  Treating all cards
        //            //  as the "first on stack".  Mostly because I would rather not hard code 5.
        //            producerInfo.isDirectPlacement = true;
        //            producerInfo.hasAncestor = true;
        //            return producerInfo;

        //        }
        //        else if (IsFoodProducer(targetCard))
        //        {
        //            if (depth == 0) producerInfo.isDirectPlacement = true;

        //            producerInfo.hasAncestor = true;
        //        }

        //        targetCard = targetCard.Parent;
        //        depth++;
        //    }

        //    return producerInfo;


        //}

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

    internal record struct FoodPlacement(bool HasAncestor, bool IsDirectPlacement);
    internal record struct FoodCount(int FirstOnProducer, int OnProduerStack);
}
