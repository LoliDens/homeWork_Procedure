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
            const string CommandShowDosseirs = "2";
            const string CommandFindDossier = "3";
            const string CommandDeleteDossier = "4";
            const string CommmandExit = "5";

            string[] fullNames = new string[3] {"Иванова Иван Иванович","Логинов Давид Алексевич","Созонов Алексей Дмитриевич" };
            string[] jobTitles = new string[3] {"Директор","Разрабочик","Менеджер" };
            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                Console.WriteLine($"Нажминте " +
                    $"\n{CommandAddDosseir} - для того чтобы добавить человека в список" +
                    $"\n{CommandShowDosseirs} - для того чтобы вывести список ФИО и дожностей" +
                    $"\n{CommandFindDossier} - найти должность по ФИО" +
                    $"\n{CommandDeleteDossier} - удалить человека из списка по ФИО");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDosseir:
                        AddDosseir(ref fullNames, ref jobTitles);
                        break;

                    case CommandShowDosseirs:
                        ShowDosseirs(fullNames, jobTitles);
                        break;

                    case CommandFindDossier:
                        FindDossier(fullNames, jobTitles);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(ref fullNames, ref jobTitles);
                        break;

                    case CommmandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Комманда не распознана");
                        break;
                }

                Console.ReadKey();                
                Console.Clear();
            }
        }

        static string [] IncreaseArray(string[] array, string userInput) 
        {
            string[] temporaryArray = new string[array.Length + 1];
           
            for (int i = 0; i < array.Length; i++) 
            {
                temporaryArray[i] = array[i];
            }

            temporaryArray[temporaryArray.Length - 1] = userInput; 
            array = temporaryArray;

            return array;         
        }

        static void AddDosseir(ref string[] fullNames, ref string[] jobTitles) 
        {
            string name;
            string job;

            Console.Write("Введите ФИО человека: ");
            name = Console.ReadLine();
            Console.Write("Введите должность человека: ");
            job  = Console.ReadLine();

            fullNames = IncreaseArray(fullNames, name);
            jobTitles = IncreaseArray(jobTitles, job);         
        }

        static void ShowDosseirs(string[] fullNames, string[] jobTitles) 
        {
            for (int i = 0; i < fullNames.Length; i++) 
            {
                Console.WriteLine($"{i+1}. {fullNames[i]}-{jobTitles[i]}");
            }
        }

        static string SearchBySurname(string fullName) 
        {
            string[] fullNames = fullName.Split(' ');
            
            return fullNames[0];
        }

        static void FindDossier(string[] fullNames, string[] jobTitles) 
        {            
            bool isUserExist = false;

            Console.WriteLine("Введите Фамилию человека кого вы хотите найти: ");
            string userInput = Console.ReadLine();

            for (int i = 0; i < fullNames.Length; i++) 
            {
                if (userInput == SearchBySurname(fullNames[i])) 
                {
                    Console.WriteLine($"ФИО - {fullNames[i]}, должность - {jobTitles[i]}");
                    isUserExist = true;
                }
            }

            if (isUserExist == false) 
            {
                Console.WriteLine("Пользователь не найден ");
            } 
        }

        static void DeleteElementArray(ref string[] array, int numberElement) 
        {
            string[] temporaryArray = new string[array.Length - 1];
            int countElement = 0;

            for (int i = 0; i < array.Length;i++) 
            {
                if(i != numberElement - 1) 
                {
                    temporaryArray[countElement] = array[i];
                    countElement++;
                }
            }

            array = temporaryArray;
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] jobTitles) 
        {        
            Console.WriteLine("Введите порядковый номер досье которого вы хотите удалить");
            int userInput = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{fullNames[userInput - 1]} - {jobTitles[userInput - 1]} был удален");
            DeleteElementArray(ref fullNames, userInput);
            DeleteElementArray(ref jobTitles, userInput);        
        }
    }
}
