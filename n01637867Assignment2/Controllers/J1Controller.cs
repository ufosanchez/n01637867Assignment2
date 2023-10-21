using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01637867Assignment2.Controllers
{
    public class J1Controller : ApiController
    {

        /// <summary>
        /// J1 Problem
        /// source: https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2006/stage1/juniorEn.pdf
        /// Chip's Fast Food is a restaurant which has a menu for its burgers, drinks, sides and desserts.
        /// The food is selected by entering a digit choice at the url api/J1/Menu/{burger}/{drink}/{side}/{dessert}.
        /// This method returns the amount of calories that the user will eat.
        /// If the user enters a number outside the range of 1-4, the response will be a message saying that they must enter the data again.
        /// </summary>
        /// <example>
        /// GET api/J1/Menu/4/4/4/5  -> "Sorry, insert your data again, you provided a value out of the numbers on the menu"
        /// GET api/J1/Menu/1/2/0/4  -> "Sorry, insert your data again, you provided a value out of the numbers on the menu"
        /// GET api/J1/Menu/4/4/4/4  -> "Your total calories count is : 0"
        /// GET api/J1/Menu/1/2/3/4  -> "Your total calories count is : 691"
        /// GET api/J1/Menu/3/2/1/2  -> "Your total calories count is : 946"
        /// GET api/J1/Menu/3/1/1/3  -> "Your total calories count is : 725"
        /// </example>
        /// <param name="burger">This parameter represent the burger choice (it's an integer between 1 and 4)</param>
        /// <param name="drink">This parameter represent the drink choice (it's an integer between 1 and 4)</param>
        /// <param name="side">This parameter represent the side choice (it's an integer between 1 and 4)</param>
        /// <param name="dessert">This parameter represent the dessert choice (it's an integer between 1 and 4)</param>
        /// <returns>
        /// Returns a string in which it describes the amount of calories according to the digits chosen by the user
        /// GET api/J1/Menu/4/4/4/4  -> "Your total calories count is : 0"
        /// </returns>


        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        [HttpGet]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            //initialization of calories at 0
            int calories = 0;

            /* I decided to implement the logic in the event that the user supplies any of the parameters outside its range (1-4), 
               if this occurs, it will send an error message */
            if (burger < 1 || burger>4 || drink < 1 || drink > 4 || side < 1 || side > 4 || dessert < 1 || dessert > 4)
            {
                return "Sorry, insert your data again, you provided a value out of the numbers on the menu";
            }
            else {
                /* If all the parameters are within the range of 1-4, the calories will be calculated using 
                   if-else series of each category. In which the calories value will be added once the conditions are met*/

                //if-else burguer menu
                if (burger == 1) { calories = calories + 461; }
                else if (burger == 2) { calories = calories + 431; }
                else if (burger == 3) { calories = calories + 420; }
                else { calories = calories + 0; }

                //if-else drink menu
                if (drink == 1) { calories = calories + 130; }
                else if (drink == 2) { calories = calories + 160; }
                else if (drink == 3) { calories = calories + 118; }
                else { calories = calories + 0; }

                //if-else side menu
                if (side == 1) { calories = calories + 100; }
                else if (side == 2) { calories = calories + 57; }
                else if (side == 3) { calories = calories + 70; }
                else { calories = calories + 0; }

                //if-else dessert menu
                if (dessert == 1) { calories = calories + 167; }
                else if (dessert == 2) { calories = calories + 266; }
                else if (dessert == 3) { calories = calories + 75; }
                else { calories = calories + 0; }

                //returning the amount of total calories
                return "Your total calories count is : " + calories;
            }

        }

    }
}
