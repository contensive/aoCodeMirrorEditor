using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Contensive.CodeMirrorEditor.Controllers {
    public class GenericController {
        //
        //=================================================================================
        /// <summary>
        /// Get a Random integer Value
        /// </summary>
        /// <param name="core"></param>
        /// <returns></returns>
        public static int getRandomInteger() {
            byte[] rngBytes = new byte[4];
            RandomNumberGenerator.Create().GetBytes(rngBytes);
            int myInt = BitConverter.ToInt32(rngBytes, 0);
            if (myInt > 0) { return myInt; }
            return 0 - myInt;
        }
        //
        //=================================================================================
        /// <summary>
        /// Get a Random integer Value between 0 and maxValue
        /// </summary>
        /// <param name="core"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int getRandomInteger(int maxValue) {
            return Convert.ToInt32(maxValue * (double)getRandomInteger() / (double)Int32.MaxValue);

        }
        //
        //=================================================================================
        /// <summary>
        /// generate a random alphanumeric string, upper and lower case text and numerics (0...9, a...z, A...Z, no special characters)
        /// </summary>
        /// <param name="core"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string getRandomString(int length) {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            for (int i = 0; i < length; i++) {
                stringChars[i] = chars[getRandomInteger(chars.Length - 1)];
            }
            return new String(stringChars);
        }
    }
}
