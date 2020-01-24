using System;
using System.Collections.Generic;

namespace DiscordBot.Commands
{
    public class DivinationData
    {
        List<string> animal = new List<string>() {"小狗","小貓","老虎","烏龜","低能兒","可憐啊" };
        List<string> adjective = new List<string>() {"","可愛的","殘忍的","白癡的","聰明的","白目的" };

        public DivinationData()
        {
        }

        public string RandomAnimal()
        {
            return animal[new Random().Next(animal.Count)];
        }

        public string RandomAdj()
        {
            return adjective[new Random().Next(adjective.Count)];
        }
    }
}
