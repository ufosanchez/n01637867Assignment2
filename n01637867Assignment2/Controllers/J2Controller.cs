using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01637867Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// J2 Problem
        /// source: https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2006/stage1/juniorEn.pdf
        /// This method will collect the number of sides of 2 different dices and will return a 
        /// string which determines how many ways the user can roll the value of 10.
        /// 
        /// The number of sides for die #1 is represented by the parameter {m}
        /// The number of sides for die #2 is represented by the parameter {n}
        /// 
        /// If the user provides data less than 1 for any side, 
        /// the response will be a string that says -> "Error, both says must have 1 or more sides"
        /// </summary>
        /// <example>
        /// GET api/J2/DiceGame/6/8  -> "There are 5 total ways to get the sum 10"
        /// GET api/J2/DiceGame/12/4 -> "There are 4 total ways to get the sum 10"
        /// GET api/J2/DiceGame/3/3  -> "There are 0 total ways to get the sum 10"
        /// GET api/J2/Dicegame/5/5  -> "There is 1 total way to get the sum 10"
        /// GET api/J2/Dicegame/5/0  -> "Error, both dice must have 1 or more sides"
        /// </example>
        /// <param name="m">Positive integer representing the number of sides on the first die</param>
        /// <param name="n">Positive integer representing the number of sides on the second die</param>
        /// <returns>
        /// Returns a string that describes the number of ways in which the result of the sum of the sides of the two dices is 10
        /// GET api/J2/DiceGame/12/4 -> "There are 4 total ways to get the sum 10"
        /// </returns>

        [Route("api/J2/DiceGame/{m}/{n}")]
        [HttpGet]
        public string DiceGame(int m, int n)
        {
            //variable which determines how many ways the user can roll the value of 10
            int countRoll = 0;

            //This variable will be the one that stores the sum of the sides and will then ask if the sum is == 10
            int sum = 0;

            //This condition will throw and terminate the code if the user provides that any of the sides of the dices is less than 1
            if (m < 1 || n < 1)
            {
                return "Error, both dice must have 1 or more sides";
            }
            else
            {
                //This double for loop compares each of the sides of dice #1 and dice #2
                for (int dice1 = 1; dice1 <= m; dice1++)
                {
                    for (int dice2 = 1; dice2 <= n; dice2++)
                    {
                     //In each iteration of dice #2 the sum of dice1+dice 2 will be made and if their sum == 10 the countRoll will increase by 1
                        sum = dice1 + dice2;

                        if (sum == 10)
                        {
                            countRoll++;
                        }

                    }
                }

                //In the case that the countRoll is 1, the message was customized so that the return string is singular
                if (countRoll == 1)
                {
                    return "There is " + countRoll + " total way to get the sum 10";
                }
                //otherwise it returns a string that describes the number of ways the user can roll the value of 10
                return "There are " + countRoll + " total ways to get the sum 10";
            }
        }
    }
}
