using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiro
{
    class ImportAttackPatterns
    {
        String fileName;
        List<Keys> attackPattern;
        StreamReader input;

        public ImportAttackPatterns(String fileName)
        {
            this.fileName = fileName;
            if(isAFile(fileName))
            {
                int numOfKeys = int.Parse(input.ReadLine());
                generatePattern(numOfKeys);
                //generate keys
            } else
            {
                Console.WriteLine("error generating key files from file path " + fileName);
            }
        }

        public bool isAFile(String filename)
        {
            try
            {
                input = new StreamReader(filename);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Keys> generatePattern(int numOfKeys)
        {
            attackPattern = new List<Keys>(numOfKeys);

            string phrase = input.ReadLine();
            string[] keySplit = phrase.Split(',');

            foreach (string word in keySplit)
            {
                Keys key = ConvertFromString(word);
                attackPattern.Add(key);
            }

            return attackPattern;
        }

        public static Keys ConvertFromString(string keystr)
        {
            return (Keys)Enum.Parse(typeof(Keys), keystr);
        }
    }
}
