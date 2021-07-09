using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Private> listOfPrivates = new List<Private>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                var splitted = input.Split();
                string type = splitted[0];
                if (type == "Private")
                {
                    Private privateSoldier = new Private(int.Parse(splitted[1]), splitted[2], splitted[3], decimal.Parse(splitted[4]));
                    listOfPrivates.Add(privateSoldier);
                    Console.WriteLine(privateSoldier.ToString());
                }
                else if (type == "LieutenantGeneral")
                {
                    List<int> listOfPrivatesIds = new List<int>();
                    for (int i = 5; i < splitted.Length; i++)
                    {
                        listOfPrivatesIds.Add(int.Parse(splitted[i]));
                    }
                    List<Private> help = new List<Private>();
                    //
                    foreach (var id in listOfPrivatesIds)
                    {
                        foreach (Private soldier in listOfPrivates)
                        {
                            if (soldier is Private)
                            {
                                if (soldier.Id == id)
                                {
                                    help.Add(soldier);
                                }
                            }
                        }
                    }
                    //foreach (Private soldier in listOfPrivates)
                    //{
                    //    if (soldier is Private)
                    //    {
                    //        foreach (var id in listOfPrivatesIds)
                    //        {
                    //            if (soldier.Id == id)
                    //            {
                    //                help.Add(soldier);
                    //            }
                    //        }
                    //    }
                    //}
                    LieutenantGeneral lieutenant = new LieutenantGeneral(int.Parse(splitted[1]), splitted[2], splitted[3], decimal.Parse(splitted[4]), help.ToArray());
                    
                    Console.WriteLine(lieutenant.ToString());
                }
                else if (type == "Commando")
                {
                    List<string> listOfMisions = new List<string>();
                    for (int i = 6; i < splitted.Length; i++)
                    {
                        listOfMisions.Add(splitted[i]);
                    }
                    try
                    {
                        Commando commando = new Commando(int.Parse(splitted[1]), splitted[2], splitted[3], decimal.Parse(splitted[4]), splitted[5], listOfMisions.ToArray());
                        Console.WriteLine(commando.ToString());
                    }
                    catch (Exception)
                    {

                    }
                    
                }
                else if (type == "Spy")
                {
                    Spy spy = new Spy(int.Parse(splitted[1]), splitted[2], splitted[3], int.Parse(splitted[4]));
                    Console.WriteLine(spy.ToString());
                }
                else if (type == "Engineer")
                {
                    List<string> listOfrepairs = new List<string>();
                    for (int i = 6; i < splitted.Length; i++)
                    {
                        listOfrepairs.Add(splitted[i]);
                    }
                    try
                    {
                        Engineer engineer = new Engineer(int.Parse(splitted[1]), splitted[2], splitted[3], decimal.Parse(splitted[4]), splitted[5], listOfrepairs.ToArray());
                        Console.WriteLine(engineer.ToString());
                    }
                    catch (Exception)
                    {

                    }
                }
                input = Console.ReadLine();
            }
            
        }
    }
}
