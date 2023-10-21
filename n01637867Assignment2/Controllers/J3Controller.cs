using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01637867Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// J3 Problem
        /// source: https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2011/stage1/juniorEn.pdf
        /// This method is responsible for printing the length of the sum sequence
        /// Each term is an integer greater than or equal 0.
        /// Its function is that each term, starting with the third, is the difference of the preceding two terms 
        /// tn+2 = tn − tn+1 for n ≥ 1
        /// The sequence terminates at tm if tm−1 < tm,
        /// 
        /// The input will be two positive numbers t1 and t2, with 0 < t2 < t1 < 10000
        /// 
        /// Basically, the sequence is responsible for making the subtraction of the terms (term1 - term2), 
        /// the result will be placed in the next position and subsequently term 1 = term 2 and term2 = term1 - term2 
        /// and at the moment that term2 > term1 will end
        /// 
        /// </summary>
        /// <example>
        /// GET api/J3/SumacSequences/120/71  -> ["The length of the sumac sequence is: 5", 
        ///                                        The sumac sequence is : 120, 71, 49, 22, 27]
        /// GET api/J3/SumacSequences/537/322  -> ["The length of the sumac sequence is: 5", 
        ///                                        The sumac sequence is : 537, 322, 215, 107, 108]
        /// GET api/J3/SumacSequences/987/603  -> ["The length of the sumac sequence is: 7", 
        ///                                        The sumac sequence is : 987, 603, 384, 219, 165, 54, 111]
        /// GET api/J3/SumacSequences/537/429  -> ["The length of the sumac sequence is: 4", 
        ///                                        The sumac sequence is : 537, 429, 108, 321]
        /// GET api/J3/SumacSequences/120/25  -> ["The length of the sumac sequence is: 4", 
        ///                                        The sumac sequence is : 120, 25, 95]
        ///                                        
        /// GET api/J3/SumacSequences/53/-2  -> ["Sorry, each term is an integer greater than or equal, insert your data again"]
        /// GET api/J3/SumacSequences/53/322  -> ["Sorry, term 2 must be less than term 1"]
        /// GET api/J3/SumacSequences/53/322  -> ["Sorry, term 1 must be less than 10000"]
        /// </example>
        /// <param name="term1">integer greater than term 2 and less than 10000</param>
        /// <param name="term2">integer less than term 2 and greater than 0</param>
        /// <returns>
        /// This method will return an array with the length of the sumac sequence given by the starting numbers term1 and term2, 
        /// as well as the sequence of the numbers (this was done to make it easier to visualize and understand the sequence)

        /// In the event that the user provides values less than 0 or that term2 is >= term1 or term1 > = 10000, 
        /// the method will return an array with only one string indicating the error
        /// 
        /// GET api/J3/SumacSequences/120/71  -> ["The length of the sumac sequence is: 5", 
        ///                                        The sumac sequence is : 120, 71, 49, 22, 27]
        /// </returns>
        [Route("api/J3/SumacSequences/{term1}/{term2}")]
        [HttpGet]
        public IEnumerable<string> SumacSequences(int term1, int term2)
        {
            //These variables are the ones that will be used to do the subtraction as well as assign the value of the sequence
            int term1Sequence = term1;
            int term2Sequence = term2;

            //This variable is the one that will increase according to the number of times the sequence is increased.
            int countSequence = 0;

            //By default the sequence has a length of 2 so this value will be added with the countSequence variable
            int countTotal = 2;

            //This string will store the sequence and then be returned as part of the string array
            string array = term1.ToString() + ", " + term2.ToString();

            //If the user provides a value less than 0, an error message will be sent
            if (term1 < 0 || term2 < 0)
            {
                return new string[] { "Sorry, each term is an integer greater than or equal, insert your data again" };
            }
            //In case the value of term2 > term1, it will send an error message since term1 must be greater than term2
            else if ( term2 >= term1)
            {
                return new string[] { "Sorry, term 2 must be less than term 1" };
            }
            //If term1 is greater than or equal to 10000, it will send an error since it must be less
            else if (term1 >= 10000)
            {
                return new string[] { "Sorry, term 1 must be less than 10000" };
            }
            else
            {
                //as long as the value of term1 is greater than term2 the while loop will run
                while (term1Sequence > term2Sequence)
                {
                    //calculation of the subtraction of term1 and term2 that results in the next number in the sequence
                    int result = term1Sequence - term2Sequence;

                    //assignment of term2 to the variable term1
                    term1Sequence = term2Sequence;

                    //assignment of the subtraction (result) to the variable term2
                    term2Sequence = result;

                    //increase the sequence counter by 1
                    countSequence++;

                    //add the value of result which will store the entire sequence of numbers
                    array = array + ", " + result.ToString()  ;
                }

                /*add the initial number of the sequence (2) with the countSequence number that was given
                after the while evaluated to false*/
                countTotal = countTotal + countSequence;

                /*return an array that will show the sequence number and in the second position show the string
                that stores all the numbers in the sequence*/
                return new string[] { "The length of the sumac sequence is: " + countTotal.ToString(), "The sumac sequence is : " + array };

            }
            
        }
    }
}
