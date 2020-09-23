using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Saving_grejs
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlSerializer orcSerializer = new XmlSerializer(typeof(List<Orc>));
            Random generator = new Random();

            List<Orc> enemieList = new List<Orc>();

            for (int i = 0; i < 10; i++)
            {
                Orc orcToAddToList = new Orc();
                orcToAddToList.posY = generator.Next(1, 10);
                orcToAddToList.posX = generator.Next(1, 10);
                orcToAddToList.hp = generator.Next(10, 100);
                orcToAddToList.Weapon = new BattleAxe();
                orcToAddToList.Weapon.rarity = "common";
                orcToAddToList.Weapon.attackSpeed = 1.2f;
                orcToAddToList.Weapon.dmg = 20;
                enemieList.Add(orcToAddToList);
                
            }
            
            FileStream file = File.Open(@"orc.xml", FileMode.OpenOrCreate);

            orcSerializer.Serialize(file, enemieList);



            file.Close();
            
        }
    }
}
