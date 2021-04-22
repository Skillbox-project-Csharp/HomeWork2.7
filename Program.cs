using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWhork
{
    class Program
    {
        class Worker
        {
            string name;
            byte age;
            float height;
            byte scoreRuslanguage;
            byte scoreHistory;
            byte scoreMath;

            public Worker()
            {

                name = "";
                age = 0;
                height = 0;
                scoreRuslanguage = 0;
                scoreHistory = 0;
                scoreMath = 0;
            }

            /// <summary>
            /// ввод данных сотрудника с клавиотуры:
            /// имя,
            /// возрост( от 18 до 120),
            /// рост( от 1 до 3 метров),
            /// баллы по русскому ( от 0 до 100 ),
            /// баллы по истории ( от 0 до 100 ),
            /// баллы по математике ( от 0 до 100 ).
            /// </summary>
            public void inputData()
            {
                string input;
                Console.WriteLine("Введите значения: ");
                Console.WriteLine(" имя: ");
                name = Console.ReadLine();
                Console.WriteLine(" возрост: ");
                while (true)
                {
                    input = Console.ReadLine();
                    if (byte.TryParse(input, out age) && age <= 120 && age >= 18)
                        break;
                    else Console.WriteLine("ошибка ввода");
                }
                Console.WriteLine(" рост: ");
                while (true)
                {
                    input = Console.ReadLine();
                    if (float.TryParse(input, out height) && height <= 3.0F && height >= 1.0F)
                        break;
                    else Console.WriteLine("ошибка ввода");
                }
                Console.WriteLine(" баллы по русскому: ");
                while (true)
                {
                    input = Console.ReadLine();
                    if (byte.TryParse(input, out scoreRuslanguage) && scoreRuslanguage <= 100)
                        break;
                    else Console.WriteLine("ошибка ввода");
                }
                Console.WriteLine(" баллы по истории: ");
                while (true)
                {
                    input = Console.ReadLine();
                    if (byte.TryParse(input, out scoreHistory) && scoreHistory <= 100)
                        break;
                    else Console.WriteLine("ошибка ввода");
                }
                Console.WriteLine(" баллы по математике: ");
                while (true)
                {
                    input = Console.ReadLine();
                    if (byte.TryParse(input, out scoreMath) && scoreMath <= 100)
                        break;
                    else Console.WriteLine("ошибка ввода");
                }
            }

            /// <summary>
            /// Расчет среднего арифметического всех баллов сотрудника
            /// </summary>
            /// <returns></returns>
            public double scoreAVG()
            {
                double avg = 0;
                avg += scoreRuslanguage;
                avg += scoreHistory;
                avg += scoreMath;
                return avg / 3;
            }

            /// <summary>
            /// Вывод информации о сотруднике 
            /// </summary>
            /// <param name="flag">Тип вывода: 1 - обычный вывод, 2 - форматированный вывод, 3 - вывод с использованием интерполяции строк, 4 - центрированный вывод </param>
            public void PrintAllInfo(byte flag)
            {
                switch (flag)
                {
                    //обычный вывод
                    case 1:
                        Console.WriteLine(" имя: " + name + "\n возрост: " + age + "\n рост: " + height + "\n баллы по русскому: " + scoreRuslanguage + "\n баллы по истории: " + scoreHistory + "\n баллы по математике: " + scoreMath);
                        break;
                    //форматированный вывод    
                    case 2:
                        string patern = " имя: {0}\n возрост: {1}\n рост: {2 : 0.00}\n баллы по русскому: {3}\n баллы по истории: {4}\n баллы по математике: {5}";
                        Console.WriteLine(patern,
                            name,
                            age,
                            height,
                            scoreRuslanguage,
                            scoreHistory,
                            scoreMath);
                        break;
                    //вывод с использованием интерполяции строк
                    case 3:
                        Console.WriteLine($" имя: {name}\n возрост: {age}\n рост: {height : 0.00}\n баллы по русскому:{scoreRuslanguage}\n баллы по истории: {scoreHistory}\n баллы по математике: {scoreMath}");
                        break;
                    //центрированный вывод
                    case 4:
                        PrintCenterMsg();
                        break;
                }
            }
            /// <summary>
            /// Вывод строки по центру строки 
            /// </summary>
            public static void PrintCenterString(string text)
            {
                Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
                Console.WriteLine(text);
            }
            /// <summary>
            /// Вывод информации о сотруднике по центру экрана
            /// </summary>
            private void PrintCenterMsg()
            {
                string[] stringMas = { "имя: "+name, "возрост: " + age, "рост: "+height, "баллы по русскому: "+ scoreRuslanguage, "баллы по истории: "+scoreHistory, "баллы по математике: "+scoreMath };
                for(int i = 0; i < stringMas.Length; i++)
                {
                    Console.SetCursorPosition((Console.WindowWidth - stringMas[i].Length) / 2, Console.WindowHeight / 2 - stringMas.Length/2+i);
                    Console.WriteLine(stringMas[i]);
                }
            }
        }

        static void Main(string[] args)
        {

            List<Worker> workers = new List<Worker>(); //Выделение памяти для работников
            for (int i = 0; i < 3; i++)
                workers.Add(new Worker());
            //Ввод данных 3 работников
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nРаботник {i+1}:");
                workers[i].inputData();
                Console.Clear();
            }

            Console.WriteLine("\nСРЕДНИЙ БАЛ:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nРаботник {i+1}:");
                Console.WriteLine($" Средний бал: {workers[i].scoreAVG()}");
                
            }

            Console.ReadKey();
            Console.Clear();
            //Вывод данных 3 сотрудников
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nРаботник {i + 1}:");
                byte index = (byte)i ;
                Console.WriteLine("Выберите способ вывода информации:");
                Console.WriteLine(" 1 - обычный вывод");
                Console.WriteLine(" 2 - форматированный вывод ");
                Console.WriteLine(" 3 - вывод с использованием интерполяции строк");
                Console.WriteLine(" 4 - центрированный вывод");

                while (true)
                {
                    string input = Console.ReadLine();
                    if (byte.TryParse(input, out index) && index >=0 && index <= 4)
                        break;
                    else Console.WriteLine("ошибка ввода");
                }
                workers[i].PrintAllInfo((byte)(index));
                Console.ReadKey();
                Console.Clear();
            }

            
            Console.ReadKey();
        }
    }
}
