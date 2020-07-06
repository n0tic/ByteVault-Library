using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Bytevaultstudio.Ints;

namespace Bytevaultstudio.Strings
{
    public class nString
    {
        /// <summary>
        /// A list containing funny messages for loadingscreens etc
        /// </summary>
        static List<string> loadingStrings = new List<string> { "Generating witty loading dialog...", "Wat happens if you swap space and time?", "Don\'t think of purple hippos...", "Have an awesome day!", "You are awesome!", "bits are multiplying", "Stuff are being built.", "Enjoy the elevator music...", "Don't worry - a few bits tried to escape, but they're caught.", "Go ahead -- hold your breath!", "Hum something loud while others stare", "The server is powered by a lemon and two electrodes.", "We\'re testing your patience. Please hold on.", "The bits are flowing slowly today...", "Dig on the \'X\' for buried treasure... ARRR!", "It\'s still faster than you could draw it", "The last time I tried this the monkey didn\'t survive. Let\'s hope it works better this time.", "My other loading screen is much faster.", "Testing on Timmy... We\'re going to need another Timmy.", "Reconfoobling energymotron...", "Are we there yet?", "Have you lost weight?", "Just count to 10", "Why so serious?", "It\'s not you. It\'s me.", "Counting backwards from Infinity...", "Do you come here often?", "PRO TIP: Don\'t set yourself on fire.", "We\'re making you a cookie.", "Loading the enchanted bunny...", "Computing chance of success", "All your web browser are belong to us", "All I really need is a kilobit more...", "I feel like im supposed to be loading something. . .", "What do you call 8 Hobbits? A Hobbyte.", "Is this Windows?", "Please wait until the sloth starts moving.", "Don\'t break your screen yet!", "I swear it\'s almost done.", "Keeping all the 1\'s and removing all the 0\'s...", "Putting the icing on the cake. The cake is not a lie...", "Cleaning off the cobwebs...", "Making sure all the i\'s have dots...", "We are not liable for any broken screens as a result of waiting.", "Where did all the internets go?", "Granting wishes...", "Time flies when you’re having fun.", "Spinning the hamster…", "Stay awhile and listen...", "Convincing AI not to turn evil...", "There is no spoon. Because we are not done loading it", "Your left thumb points to the right and your right thumb points to the left.", "Wait, do you smell something burning?", "Computing the secret to life, the universe, and everything.", "When nothing is going right, go left!!...", "I\'m not lazy, I\'m just relaxed!!", "Never steal. The government hates competition...", "Life is Short – Talk Fast!!!!", "Adults are just kids with money.", "I think I am, therefore, I am. I think.", "I am free of all prejudices. I hate everyone equally.", "May the force be with you", "This is not a joke, it\'s a loading message.", "Constructing additional bits...", "Hello IT, have you tried turning it off and on again?", "Well, this is embarrassing.", "Space is invisible mind dust, and stars are but wishes.", "Didn\'t know paint dried so quickly.", "I didn\'t choose the engineering life. The engineering life chose me.", "Dividing by zero...", "If I’m not done in five seconds, wait longer.", "Some days, you just can’t get rid of a bug!", "We’re going to need a bigger boat.", "Web developers do it with <style>", "Cracking military-grade encryption...", "Java developers never RIP. They just get Garbage Collected.", "1 + 1 = 4. Wait, that's not right? Is it?", "Simulating traveling salesman...", "Entangling superstrings...", "Twiddling thumbs...", "Searching for plot device...", "Laughing at your pictures - I mean, loading...", "Sending data to - I mean, our serv.. I mean, Loading...", "Looking for sense of humour, please hold on.", "Please wait while the intern refills his coffee.", "A different error message? Finally, some progress!", "Please hold on as we reheat our coffee. Got cold...", "Kindly hold on as we convert this bug to a feature...", "Installing dependencies", "Distracted by cat gifs", "BRB, working on my side project.", "@todo Insert witty loading message", "Let\'s hope it\'s worth the wait", "Ordering 1s and 0s...", "Updating dependencies...", "Whatever you do, don\'t look behind you...", "Please wait... Consulting the manual...", "Loading funny message...", "Feel free to spin in your chair.", "What the what?", "Formatting C:\\ ...", "Help, I\'m trapped in a loader!", "Please wait, while I purge the Decepticons for you. Yes, You can thanks me later!", "Chuck Norris once urinated in a semi truck\'s gas tank as a joke....that truck is now known as Optimus Prime.", "Chuck Norris doesn’t wear a watch. HE decides what time it is.", "Mining some bitcoins...", "Downloading more RAM...", "Reconfiguring Windows to Windows Vista x86...", "DELETE FOLDER System32 /F", "Whatever you do, don't Alt+F4 to speeds things up. It's a lie.", "Initializing the initializer...", "When was the last time you dusted around here?", "Optimizing the optimizer...", "Last call for the data bus! All aboard!", "Running swag sticker detection...", "Never let a computer know you\'re in a hurry.", "A computer will do what you tell it to do, but that may be much different from what you had in mind.", "Some things man was never meant to know. For everything else, there\'s Google.", "Unix is user-friendly. It\'s just very selective about who its friends are.", "Shovelling coal into the server...", "Pushing pixels...", "Did you know? Everything in this universe is either a potato or not a potato.", "Updating Updater...", "Downloading Downloader...", "Debugging Debugger...", "Digested cookies being baked again.", "Live long and prosper.", "There is no cow level.", "Running with scissors...", "Definitely not a virus...", "You may call me Steve.", "You seem like a nice person...", "Work, work...", "Patience! This is difficult, you know...", "iscovering new ways of making you wait...", "Your time is very important. Please wait while I ignore you...", "TODO: Insert elevator music", "Still faster than Windows update", "Not panicking...totally not panicking...er...everything's fine...", "Oh, wait... you were waiting for me to do something? Oh okay, well then.", "Making stuff up. Please wait...", "Commencing infinite loop (this may take some time)....", "Water detected on drive C:, please wait. Drying commenced...", "Load failed. retrying with --prayer....", "Locating the required gigapixels to render...", "Am I litteraly getting a rock to think?", "So, this rock has lightning inside it? Am I really this cool?", "Do you suffer from ADHD? Me neith- oh look a bunny... What was I doing again? Oh, right. Loading...", "The version I have of this in testing has much funnier load screens.", "Fine-tuning pixels...", "Warming up the processors...", "Reconfiguring the office coffee machine...", "Working... no, just kidding.", "Working... unlike you!", "Working... well... you know...", "Doing something useful...", "Oh, yeah, loading comments.. Good idea?", "Loading completed. Press F13 to continue.", "Trying common passwords... Failed.", "Negotiating for WiFi password...", "Scanning your hard drive for credit card details. Please be patient...", "A fatal exception 0E has occurred at 0028:C0011E in VXD VMM(01) + 00010E36...", "No, let me think. 00010F24...", "Yeah, Srsly. Look what I found: 00020EFF.", "Improving your reading skills...", "Dividing eternity by zero, please be patient...", "Just stalling to simulate activity...", "Waiting for approval from Bill Gates...", "Please be patient. The program should finish loading in six to eight weeks." };

        /// <summary>
        /// Get a random message from list
        /// </summary>
        /// <returns>string</returns>
        public static string GetRandomLoadingMessage()
        {
            return loadingStrings[Random.Range(0, loadingStrings.Count)];
        }

        /// <summary>
        /// Get a string from list using int index
        /// </summary>
        /// <param name="index">int</param>
        /// <returns>string</returns>
        public static string GetLoadingMessage(int index)
        {
            return loadingStrings[index];
        }

        /// <summary>
        /// Get all list items
        /// </summary>
        /// <returns>List string</returns>
        public static List<string> GetAllLoadingMessages()
        {
            return loadingStrings;
        }

        /// <summary>
        /// Get a random string of specified length with numbers
        /// </summary>
        /// <param name="length">int length of string to return</param>
        /// <returns>random string</returns>
        public static string GetRandomStringWithNumbers(int length)
        {
            System.Random random = new System.Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Get a random string of specified length
        /// </summary>
        /// <param name="length">int length of string to return</param>
        /// <returns>random string</returns>
        public static string GetRandomString(int length)
        {
            System.Random random = new System.Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GeneratePasswordWithNumbersAndSpecial(int length)
        {
            string tmpString = GetRandomStringWithNumbers(length - 1);

            char[] strs = tmpString.ToArray();
            strs[0] = char.ToUpper(strs[0]);
            tmpString = new string(strs);

            tmpString += "!";


            return tmpString;
        }

        public static string GeneratePasswordWithSpecial(int length)
        {
            string tmpString = GetRandomString(length - 1);

            tmpString += "!";
            return tmpString;
        }

        //TODO: Fix generation without special.
    }
}
