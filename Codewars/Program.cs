using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Codewars
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            IsSequenceValid("1 2 3 4");
            IsSequenceValid("1 2 3 4 a");
            IsSequenceValid("1 3 4 5");
            SumOfBinaryDigits(1234);
            FindNumberOfSubstringsInAString("a a a  b  c c  d d d d  e e e e e");
            FindFirstUniqueLetterInString("stress");
            findTheSingleton(new int[] { 2, 4, 5, 4, 2 });
            footballSession("arsenal");
            starWarsSimplified("Luke Skywalker");
            morseCode(false, "The wizard quickly jinxed the gnomes before they vaporized.");
            morseCode(true, "- .... .  .-- .. --.. .- .-. -..  --.- ..- .. -.-. -.- .-.. -.--  .--- .. -. -..- .  -.. -  .... .  --. -. --- -- .  ... -... .  ..-. --- .-. .  - .... .  -.-- ...- .- .--. --- .-. .. --.. .  -.. .-.-.-");
            commonAncestor(13, 15);
            commonAncestor(25, 100);
            commonAncestor(11000, 11103);
            romanNumbers(7);
            romanNumbers(15);
            romanNumbers(92);
            romanNumbers(312);
            romanNumbers(999);
            romanNumbers(2764);
            maximumSubarray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            maximumSubarray(new int[] { 10, 14, 52, -2, 10, -22, -40, -3, 11 });
            stringTheory("ThIs is p");
        }
        #endregion Main
        #region IsASequenceValid
        static int IsSequenceValid(string sequence)
        {
            /*
                https://www.codewars.com/kata/5512e5662b34d88e44000060
                Check if item part of broken sequence or not
            */
            Console.WriteLine($"is this sequence valid? {sequence}");
            if (sequence == null) return 0;
            if (sequence == "") return 0;
            // check for invalid characters
            foreach(char c in sequence)
            {
                if (!(Char.IsDigit(c)||Char.IsWhiteSpace(c)))
                {
                    Console.WriteLine($"Invalid character {c} present");
                }
            }
            string[] numbers = sequence.Split(" ");
            int previousNumber = 0;
            int missingNumber = 0;
            foreach(var number in numbers)
            {
                if (int.TryParse(number, out int result))
                {
                    if (result - previousNumber != 1)
                    {
                        missingNumber = previousNumber + 1;
                        break;
                    }
                }
            }
            if (missingNumber > 0)
            {
                Console.WriteLine($"Number {missingNumber} is missing from sequence");
                return missingNumber;
            }
            return 0;
        }
        #endregion IsASequenceValid
        #region SumOfBinaryDigits
        static int SumOfBinaryDigits(int n)
        {
            Console.WriteLine($"Printing sum of binary digits given integer {n}");
            // null 
            if (n <= 0) return 0;
            if (n == 1) return 1;
            var binary = Convert.ToString(n, 2);
            Console.WriteLine($"{n} as binary is {binary}");
            int total = 0;
            foreach(var item in binary)
            {
                Console.Write($"{item}, ");
                var sb = new System.Text.StringBuilder();
                sb.Append(item);
                int.TryParse(sb.ToString(),out int result);
                total += result;
            }
            Console.WriteLine($"Total of digits is {total}");
            // here is an easier way
            int total2 = binary.Count(item => item == '1');
            return total2;
        }
        #endregion SumOfBinaryDigits
        #region FindNumberOfSubstringsInAString
        static string[] FindNumberOfSubstringsInAString(string s) {
            /*
            https://www.codewars.com/kata/51e056fe544cf36c410000fb/train/csharp
            find occurrences of substring in string
            */

            return new string[0];
        }
        #endregion FindNumberOfSubstringsInAString
        #region FindFirstUniqueLetterInString


        static string FindFirstUniqueLetterInString(string s)
        {
            /*
            https://www.codewars.com/kata/52bc74d4ac05d0945d00054e/train/csharp
            3 October 2020
            Found this very easy! Grade 2 out of 10 for difficulty
            */
            Console.WriteLine($"\n\nFinding first unique letter in string {s}");
            var lower = s.ToLower();
            string foundLetter = "";
            for (var i = 0; i < lower.Length; i++)
            {
                var match = false;
                var letter = lower[i];
                for (var j = 0; j < lower.Length; j++)
                {
                    if (i != j)
                    {
                        Console.WriteLine($"comaring {letter} with {lower[j]}");
                        if (letter == lower[j])
                        {
                            match = true;
                            break;
                        }
                    }
                }
                if (match == false)
                {
                    // get original case
                    foundLetter = s[i].ToString();
                    break;
                }
            }
            Console.WriteLine($"found letter is {foundLetter}");
            return foundLetter;
        }
        #endregion FindFirstUniqueLetterInString


        static int findTheSingleton(int[] student_list)
        {

            Console.WriteLine("\n\nFinding the student with no partner");

            /*
            https://www.codewars.com/kata/5a145ab08ba9148dd6000094/train/csharp
            3 October 2020

            students in pairs 

            one student does not have a partner

            find the student with no partner 

            try to find efficient solution

            eg 2 4 5 4 2  output 5

            */
            
            int single_student_number = 0;

            Dictionary<int, int> matches = new Dictionary<int, int>();

            Console.WriteLine("student list is");
            foreach (int student_id in student_list) {
                Console.Write($"{student_id}");

                int value = 0;
                if (matches.TryGetValue(student_id, out value)) {
                    // remove
                    matches.Remove(student_id);
                } else {
                    // add    		
                    matches.Add(student_id,1);
                }
            }



            foreach( KeyValuePair<int, int> kvp in matches )
            {
                // Console.WriteLine("Key = {0}, Value = {1}",
                //    kvp.Key, kvp.Value);
                single_student_number = kvp.Key;
            }

            Console.WriteLine($"\nsingle student number is {single_student_number}\n\n");

            return single_student_number;
        }
    





        static int footballSession(string teamKey) {

            Console.WriteLine("\n\nFinding total goals scored by team\n");

            /*

            how many goals scored by a team 

            json data file provided

            https://s3.eu-west-1.amazonaws.com/hackajob-assets1.p.hackajob/challenges/football_session/football.json

            {
                name
                rounds : [

                    name: "Matchday 1",
                    matches: [
                        {
                            date: "yyyy-mm-dd",
                            team1: { key, name, code},
                            team2: { key, name, code},
                            score1: 2,
                            score2: 3
                        } ,

                        {
                            date: "yyyy-mm-dd",
                            team1: { key, name, code},
                            team2: { key, name, code},
                            score1: 2,
                            score2: 3
                        }
                    ]
                
                ]
            }

            input string teamkey matches team.key either team1.key or team2.key

            output is total number of goals scored by that team 

            lopp over every matchday

                loop over every match

                    check if team1.key or team2.key matches teamkey

                    if team1.key matches then total up score1
                    if team2.key matches then total up score2

            just get total at end

            should be simple calculation

            will have to use http library to get data

            */

            int seasonGoalTally = 0;

            Task<string> result =  GetResponseString();

            result.Wait();

            Console.WriteLine("data has returned");

            var jsonResult = result.Result;

            dynamic dynamicResultObject = JsonConvert.DeserializeObject(jsonResult);

            string resultAsString = Convert.ToString(jsonResult);

            Console.WriteLine("data has returned 2");

            string premiershipName = dynamicResultObject.name;

            Console.WriteLine(premiershipName);

            Newtonsoft.Json.Linq.JArray rounds = dynamicResultObject.rounds;

            Console.WriteLine($"there are {rounds.Count} rounds");

            //Console.WriteLine(resultAsString);

            foreach (dynamic round in rounds) 
            {
                //Console.WriteLine(round.name);

                var matchDayMatches = round.matches;

                foreach(dynamic match in matchDayMatches) {
                    string team1 = match.team1.key;
                    string team2 = match.team2.key;
                    int score1 = match.score1;
                    int score2 = match.score2;

                    //Console.WriteLine($"team1 {team1} team2 {team2} score1 {score1} score2 {score2}");

                    if (team1 == teamKey){
                        //Console.WriteLine($"{team1} score {score1}");
                        seasonGoalTally += score1;
                    }

                    if (team2 == teamKey){
                        //Console.WriteLine($"{team2} score {score2}");
                        seasonGoalTally += score2;
                    }

                }
            }

            Console.WriteLine($"total goals scored by {teamKey} is {seasonGoalTally}");

            return seasonGoalTally;
        }

        static public async Task<string> GetResponseString()
        {
            var httpClient = new HttpClient();

            Console.WriteLine("awaiting response");

            string dataUrl = "https://s3.eu-west-1.amazonaws.com/hackajob-assets1.p.hackajob/challenges/football_session/football.json";

            var response = await httpClient.GetAsync(dataUrl);

            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }
        


        static int starWarsSimplified(string starWarsCharacterName) {

            Console.WriteLine("\n\nFinding number of films a character appeared in\n");

            /*

            Given character name find out how many films they appeared in

            SWAPI API at 
            
            https://challenges.hackajob.co/swapi/documentation
            
            https://challenges.hackajob.co/swapi/api/
            
            Ensure we url encode the character name ie spaces to %.. characters

            person

            https://challenges.hackajob.co/swapi/api/people/?search= + character)
            
            get number of films they appeared in
            
            INPUT
            string    character

            OUTPUT
            int    numberOfFilms

            EXAMPLE
            Input
            "Luke Skywalker"
            Output
            5

            query api 

            api/people/?search=Luke%20Skywalker

            it looks like we want to get their id and from there query

            /people/{id}

            which will return a json object with films array

            we can then count the number of films


            */
            
            

            Task<string> result = GetStarWarsCharacterData(starWarsCharacterName);
            result.Wait();
            Console.WriteLine("data has returned");
            var jsonResult = result.Result;
            dynamic dynamicResultObject = JsonConvert.DeserializeObject(jsonResult);
            string resultAsString = Convert.ToString(jsonResult);
            Console.WriteLine("data has returned 2");

            int? resultDataCount = dynamicResultObject.count;

            if (resultDataCount >= 1) {
                Console.WriteLine($"data items returned count is {resultDataCount}");
            }

            // assume first item for now ie index 0

            var characterData = dynamicResultObject.results[0];

            var characterFilms = characterData.films;

            var characterFilmCount = characterFilms.Count;

            Console.WriteLine($"film count is {characterFilmCount}");

            //Console.WriteLine(resultAsString);

            return characterFilmCount;

            
        }

        static public async Task<string> GetStarWarsCharacterData(string characterName)
        {
            var httpClient = new HttpClient();

            Console.WriteLine("awaiting response");

            string baseUrl = "https://challenges.hackajob.co/swapi/api/people/?search=";

            var encodedCharacterName = Uri.EscapeDataString(characterName);

            string dataUrl = baseUrl + encodedCharacterName;

            Console.WriteLine($"obtaining data for url {dataUrl}");

            var response = await httpClient.GetAsync(dataUrl);

            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }


        static public string morseCode(bool morseToEnglish, string textToTranslate) {
  

            var morseCodeDictionary = new Dictionary<char, string>();

            morseCodeDictionary.Add('a', ".-");
            morseCodeDictionary.Add('b', "-...");
            morseCodeDictionary.Add('c', "-.-.");
            morseCodeDictionary.Add('d', "-..");
            morseCodeDictionary.Add('e', ".");
            morseCodeDictionary.Add('f', "..-.");
            morseCodeDictionary.Add('g', "--.");
            morseCodeDictionary.Add('h', "....");
            morseCodeDictionary.Add('i', "..");
            morseCodeDictionary.Add('j', ".---");
            morseCodeDictionary.Add('k', "-.-");
            morseCodeDictionary.Add('l', ".-..");
            morseCodeDictionary.Add('m', "--");
            morseCodeDictionary.Add('n', "-.");
            morseCodeDictionary.Add('o', "---");
            morseCodeDictionary.Add('p', ".--.");
            morseCodeDictionary.Add('q', "--.-");
            morseCodeDictionary.Add('r', ".-.");
            morseCodeDictionary.Add('s', "...");
            morseCodeDictionary.Add('t', "-");
            morseCodeDictionary.Add('u', "..-");
            morseCodeDictionary.Add('v', "...-");
            morseCodeDictionary.Add('w', ".--");
            morseCodeDictionary.Add('x', "-..-");
            morseCodeDictionary.Add('y', "-.--");
            morseCodeDictionary.Add('z', "--..");
            morseCodeDictionary.Add(' ', "  ");
            morseCodeDictionary.Add('.', ".-.-.-");
            morseCodeDictionary.Add(',', "--..--");
            morseCodeDictionary.Add('?', "..--..");
            morseCodeDictionary.Add('!', "-.-.--");
            morseCodeDictionary.Add('0', "-----");
            morseCodeDictionary.Add('1', ".----");
            morseCodeDictionary.Add('2', "..---");
            morseCodeDictionary.Add('3', "...--");
            morseCodeDictionary.Add('4', "....-");
            morseCodeDictionary.Add('5', ".....");
            morseCodeDictionary.Add('6', "-....");
            morseCodeDictionary.Add('7', "--...");
            morseCodeDictionary.Add('8', "---..");
            morseCodeDictionary.Add('9', "----.");
            morseCodeDictionary.Add('&', ".-...");
            morseCodeDictionary.Add('-', "-....-");

            string spaceString = " ";
            string translatedText = "";
            char space = (char)32;

            if (morseToEnglish) {

                if (textToTranslate == "") {
                                                                    translatedText = "Invalid Morse Code Or Spacing";

                  return translatedText;
                }

                var morseToTranslateArray = textToTranslate.Split(" ");
                bool dontAddFollowingSpace = false;
                int sequentialSpacesDetected = 0;

                foreach (string morse in morseToTranslateArray) {

                    var morseKey = morseCodeDictionary.FirstOrDefault(x => x.Value == morse).Key;

                    Console.WriteLine($"morse is {morse} which maps to {morseKey}");

                    if (morseKey == ' ') {
                        Console.WriteLine("space string detected");
                    }

                    if (morseKey == space) {
                        Console.WriteLine("space character detected");
                    }

                    if (morseKey == '\0') {
                        Console.WriteLine("minimum character detected");
                    }

                    if (morseKey != '\0') {
                        translatedText += morseKey;
                        sequentialSpacesDetected = 0;
                    } else {
                        sequentialSpacesDetected++;
                        if (sequentialSpacesDetected >= 3){
                            translatedText = "Invalid Morse Code Or Spacing";
                            break;
                        }
                        if (dontAddFollowingSpace) {
                            dontAddFollowingSpace = false;
                        } else {
                            Console.WriteLine("space detected");
                            translatedText += " ";
                            dontAddFollowingSpace = true;
                        }
                    }

                }

            }   else {

                var textToTranslateUpper = textToTranslate.ToLower();

                var textToTranslateArray = textToTranslateUpper.ToCharArray();

                foreach (char c in textToTranslateArray) {

                    Console.WriteLine($"character is {c}"); 

                    if (morseCodeDictionary.ContainsKey(c)) {
                        translatedText += morseCodeDictionary[c];
                    } else {
                        translatedText = "Invalid Morse Code Or Spacing";
                        break;
                    }

                    // add space between letters
                    if (c != ' ') {
                        translatedText += spaceString;
                    }

                }
            }

            Console.WriteLine($"translated text is {translatedText}");

            return translatedText;
        }
			

        static int commonAncestor(int node1, int node2) {
            /*

            Find the first common ancester given two nodes in a binary tree

            index starts at 1 at left and increases to the right 

            INPUT              int    index1                   int    index2

            OUTPUT              int    indexCommonAncestor


            EXAMPLES
            Input
            13, 15
            Output
            3




            1

            2                   3

            4           5       6           7


            8   9     10  11   12  13     14  15

            Input
            11, 13
            Output
            1

            Input
            10, 11
            Output
            5


            so left hand edge has powers of 2

            so given any number to find its ancestor we divide by 2 and ignore the remainder

            ie node 13 is 13/2 = 6
            and node 15 is 15/2 = 7

            we then repeat this process

            6/2 = 3
            7/2 = 3

            so this is our answer

            easy! 

            also the nodes might start on different levels so we have to factor this in as well 

            so first we have to get the level by dividing by 2 until we get to 1

            then we can do the division by 2 to get the common ancestor

            or we could just get a list of all ancestor nodes then pick the biggest common one?

            */


            Console.WriteLine("\n\nFinding common ancestor\n");
            int commonAncestor = 1;

            int level1 = 0;
            int level2 = 0;

            int ancestor1 = node1;
            int ancestor2 = node2;

            while (ancestor1 > 1) {
                ancestor1 = ancestor1 / 2;
                level1++;
            }

            while (ancestor2 > 1) {
                ancestor2 = ancestor2 / 2;
                level2++;
            }

            Console.WriteLine($"level1 is {level1} level2 is {level2}");


            if (level1 > level2) {
                while (level1 > level2) {
                    node1 = node1 / 2;
                    level1--;
                }
            } else if (level2 > level1) {
                while (level2 > level1) {
                    node2 = node2 / 2;
                    level2--;
                }
            }

            while (node1 != node2) {
                node1 = node1 / 2;
                node2 = node2 / 2;
            }

            Console.WriteLine($"common ancestor is {node1}");

            commonAncestor = node1;

            return commonAncestor;
        }



        static string romanNumbers(int number) {

            /*

            translate number to roman numeral

            roman numerals are

            I 

            V

            X

            L

            C

            D

            M

            so we have to break number into its components 

            let's choose a simple example 7

            let's increase to 15 now

            */

            int workingNumber = number;
            string romanNumeral = "";

            // thousands

            while (workingNumber >= 1000) {
                Console.WriteLine("M");
                romanNumeral += "M";
                workingNumber -= 1000;
            }

            // hundreds

            if (workingNumber >= 900) {
                Console.WriteLine("CM");
                romanNumeral += "CM";
                workingNumber -= 900;
            }

            if (workingNumber >= 500) {
                Console.WriteLine("D");
                romanNumeral += "D";
                workingNumber -= 500;
            }

            if (workingNumber >= 400) {
                Console.WriteLine("CD");
                romanNumeral += "CD";
                workingNumber -= 400;
            }

            while (workingNumber >= 100) {
                Console.WriteLine("C");
                romanNumeral += "C";
                workingNumber -= 100;
            }


            //tens

            if (workingNumber >= 90){
                Console.WriteLine("XC");
                romanNumeral += "XC";
                workingNumber -= 90;
            }

            if (workingNumber >= 50){
                Console.WriteLine("L");
                romanNumeral += "L";
                workingNumber -= 50;
            }

            if (workingNumber >= 40){
                Console.WriteLine("XL");
                romanNumeral += "XL";
                workingNumber -= 40;
            }

            while (workingNumber >= 10){
                Console.WriteLine("X");
                romanNumeral += "X";
                workingNumber -= 10;
            }

            Console.WriteLine($"working number is {workingNumber}");

            //units

            if (workingNumber == 9){
                Console.WriteLine("IX");
                romanNumeral += "IX";
                workingNumber -= 9;
            }

            if (workingNumber >= 5) {
                Console.WriteLine("V");
                romanNumeral += "V";
                workingNumber -= 5;
            }

            if (workingNumber == 4) {
                Console.WriteLine("IV");
                romanNumeral += "IV";
                workingNumber -= 4;
            }

            while (workingNumber > 0) {
                Console.WriteLine("I");
                romanNumeral += "I";
                workingNumber -= 1;
            }

            Console.WriteLine($"roman numeral for {number} is {romanNumeral}");



            return romanNumeral;

        }

        static int maximumSubarray(int[] inputArray) {
            
            Console.WriteLine("\n\nFinding maximum sum of contiguous subarray\n");  


            /*

            find maximum possible sum of contiguous subarray

            if the highest element in the array is greater than the sum then return that 

            INPUT               int[] a

            OUTPUT               int    maximum_sum

            [-2,1,-3,4,-1,2,1,-5,4]               maximum sum = 6  which is sum of -2,1,-3,4,-1,2,1,

            second example 10,14,52,-2,10,-22,-40,-3,11      10+14+52-2+10 = 84

            third example   -2 1 2 -4 13 23 is 36

            -2 -10 -4   is      -2

            1 1 1 -1 1 1   is 4

            ok can do the brute force method then 


            */

            Console.WriteLine("input array is");
            Console.WriteLine(string.Join(",", inputArray));

            int maximumSum = -1000;

            for (int i = 0; i < inputArray.Length; i++) {
                int sum = 0;
                for (int j = i; j < inputArray.Length; j++) {
                    sum += inputArray[j];
                    if (sum > maximumSum) {
                        maximumSum = sum;
                    }
                }
            }

            Console.WriteLine($"maximum sum is {maximumSum}");

            return maximumSum;

        }


        static string stringTheory(string inputString) {

            Console.WriteLine("\n\nString Theory\n");

            /*

            given an input string of any type of characters

            count vowels

            count consonants

            ::

            reverse the order of words

            reverse the case 

            ::

            instead of a space put a dash between words

            ::


            add 'pv' before any vowel

            example

            nr_vowels nr_consonants::reversed_p_with_reversed_cases::every-word-in-p::p_wpvith_inspvertpved_strpving_pv

            Input              "ThIs is p"
            Output              2 5::P IS tHiS::ThIs-is-p::ThpvIs pvis p
                                two vowels I 
                                five consonants
                                reverse word order and reverse case  P IS tHiS
                                add dash instead of space  ThIs-is-p
                                add pv before vowels  ThpvIs pvis p

            Seems easy enough just a lot of work and moving parts

            */

            // firstly identify vowels and consonants

            Console.WriteLine($"input string is {inputString}");

            int vowelCount = 0;
            int consonantCount = 0;

            string vowels = "aeiou";
            string consonants = "bcdfghjklmnpqrstvwxyz";

            // parse string and count vowels and consonants

            foreach (char c in inputString) {
                if (vowels.Contains(Char.ToLower(c))) {
                    vowelCount++;
                } else if (consonants.Contains(Char.ToLower(c))) {
                    consonantCount++;
                }
            }

            Console.WriteLine($"vowel count is {vowelCount} consonant count is {consonantCount}");

            // reverse the order of words

            string[] words = inputString.Split(" ");

            Array.Reverse(words);

            string reversedWords = string.Join(" ", words);

            Console.WriteLine($"reversed words are {reversedWords}");

            // reverse the case

            string reversedCase = "";

            foreach (char c in reversedWords) {
                if (Char.IsLower(c)) {
                    reversedCase += Char.ToUpper(c);
                } else if (Char.IsUpper(c)) {
                    reversedCase += Char.ToLower(c);
                } else {
                    reversedCase += c;
                }
            }

            Console.WriteLine($"reversed case is {reversedCase}");

            // replace space with dash

            string replacedSpace = inputString.Replace(" ", "-");

            Console.WriteLine($"replaced space with dash {replacedSpace}");

            // add pv before vowels

            string pvBeforeVowels = "";

            foreach (char c in inputString) {
                if (vowels.Contains(Char.ToLower(c))) {
                    pvBeforeVowels += "pv" + c;
                } else {
                    pvBeforeVowels += c;
                }
            }

            Console.WriteLine($"pv before vowels {pvBeforeVowels}");

            // now just concatenate the output strings into one final output string

            string finalOutput = $"{vowelCount} {consonantCount}::{reversedCase}::{replacedSpace}::{pvBeforeVowels}";

            Console.WriteLine($"final output is {finalOutput}");

            return finalOutput;            

        }

	}
}
