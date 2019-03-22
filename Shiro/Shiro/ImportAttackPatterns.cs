using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ImportAttackPatterns
{
    String fileName;
    List<Keys> attackPattern;
    StreamReader input;
    int numOfKeys;

    public ImportAttackPatterns(String fileName)
    {
        //D:\Profiles\dkt7290\Source\Repos\gdaps2-2185-section_2_Team_32\Shiro\Shiro\bin\Windows\x86\Debug\AttackPatterns\ratAttackOne.txt
        string originalLoc = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        this.fileName = (Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(originalLoc).FullName).FullName).FullName).FullName).FullName) 
            + ("\\AttackPatterns\\" + fileName);
        //this.fileName = fileName;
        if (isAFile(this.fileName))
        {

            numOfKeys = int.Parse(input.ReadLine());
            generatePattern();
            Console.WriteLine("keys generated");
            //generate keys
        }
        else
        {
            Console.WriteLine("error generating key files from file path " + fileName);
        }
    }

    public List<Keys> AttackPattern
    {
        get
        {
            return attackPattern;
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

    public void generatePattern()
    {
        attackPattern = new List<Keys>(numOfKeys);

        string phrase = input.ReadLine();
        string[] keySplit = phrase.Split(',');

        foreach (string word in keySplit)
        {
            Keys key = ConvertFromString(word);
            attackPattern.Add(key);
        }
    }

    public static Keys ConvertFromString(string keystr)
    {
       switch(keystr)
        {
            case "Keys.Down":
                return Keys.Down;

            case "Keys.Left":
                return Keys.Left;

            case "Keys.Right":
                return Keys.Right;

            case "Keys.Up":
                return Keys.Up;

            default:
                return Keys.None;
        }
    }
}

