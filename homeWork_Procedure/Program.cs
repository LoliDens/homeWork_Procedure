using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_Procedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDosseir = "1";
            const string CommandShowDosseir = "2";
            const string CommandFindDossier = "3";
            const string CommandDeleteDossier = "4";
            const string CommmandExit = "5";

            string[] fullName = new string[3] {"Иванова Иван Иванович","Логинов Давид Алексевич","Созонов Алексей Дмитриевич" };
            string[] jobTitle = new string[3] {"Директор","Разрабочик","Менеджер" };
            bool isExit = true;
            string userInput;

            while (isExit == true)
            {
                Console.WriteLine($"Нажминте " +
                    $"\n{CommandAddDosseir} - для того чтобы добавить человека в список" +
                    $"\n{CommandShowDosseir} - для того чтобы вывести список ФИО и дожностей" +
                    $"\n{CommandFindDossier} - найти должность по ФИО" +
                    $"\n{CommandDeleteDossier} - удалить человека из списка по ФИО");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDosseir:
                        AddDosseir(ref fullName, ref jobTitle);
                        break;

                    case CommandShowDosseir:
                        ShowDosseir(fullName, jobTitle);
                        break;

                    case CommandFindDossier:
                        FindDossier(fullName, jobTitle);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(ref fullName, ref jobTitle);
                        break;

                    case CommmandExit:
                        isExit = false;
                        break;

                    default:
                        Console.WriteLine("Комманда не распознана");
                        break;
                }

                Console.ReadKey();                
                Console.Clear();
            }
        }

        static void IncreaseArrays( ref string[] array) 
        {
            string[] temporaryArray = new string[array.Length + 1];
           

            for (int i = 0; i < array.Length; i++) 
            {
                temporaryArray[i] = array[i];
            }

            array = temporaryArray;     
        }

        static void AddRecord(ref string[] array, string line)
        {
            array[array.Length - 1] = line;
        }

        static void AddDosseir(ref string[] fullNames, ref string[] jobTitles) 
        {
            string name;
            string job;

            Console.Write("Введите ФИО человека: ");
            name = Console.ReadLine();
            Console.Write("Введите должность человека: ");
            job  = Console.ReadLine();

            IncreaseArrays(ref fullNames);
            IncreaseArrays(ref jobTitles);
            AddRecord(ref fullNames, name);
            AddRecord(ref jobTitles, job);            
        }

        static void ShowDosseir(string[] firstArray, string[] secondArray) 
        {
            for (int i = 0; i < firstArray.Length; i++) 
            {
                Console.WriteLine($"{i+1}. {firstArray[i]}-{secondArray[i]}");
            }
        }

        static void FindDossier(string[] fullName, string[] jobTitle) 
        {
            string userInput;
            bool isUserExits = false;
            Console.WriteLine("Введите ФИО человека кого вы хотите найти: ");
            userInput= Console.ReadLine();

            for (int i = 0; i < fullName.Length; i++) 
            {
                if (userInput == fullName[i]) 
                {
                    Console.WriteLine($"ФИО - {fullName[i]}, должность - {jobTitle[i]}");
                    isUserExits = true;
                }
            }

            if (isUserExits == false) 
            {
                Console.WriteLine("Пользователь не найден ");
            } 
        }

        static void DeleteElementArray(ref string[] array, int numberElemet) 
        {
            string[] temperaryAray = new string[array.Length - 1];
            int countElemet = 0;

            for (int i = 0; i < array.Length;i++) 
            {
                if(i != numberElemet - 1) 
                {
                    temperaryAray[countElemet] = array[i];
                    countElemet++;
                }
            }

            array = temperaryAray;
        }

        static void DeleteDossier(ref string[] fullName, ref string[] jobTitles) 
        {
            string[] temporeryFullName = new string[fullName.Length - 1];
            string[] tempereryJobTitle = new string[jobTitles.Length - 1];
            int userInput;
            int countRecords = 0;

            Console.WriteLine("Введите порядковый номер досье которого вы хотите удалить");
            userInput =Convert.ToInt32(Console.ReadLine());

            DeleteElementArray(ref fullName, userInput);
            DeleteElementArray(ref jobTitles, userInput);

            Console.WriteLine($"{fullName[userInput-1]} - {jobTitles[userInput-1]} был удален");
            fullName = temporeryFullName;
            jobTitles = tempereryJobTitle;
        }
    }
}
