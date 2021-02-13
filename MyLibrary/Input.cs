using System;

namespace MyLibrary
{
    public static class Input
    {
        public static int Integer(string msg)
        {
            int result = 0; //Полученное число
            bool ok; // Показатель того, что парсинг успешен

            do
            {
                try
                {
                    ok = true;
                    Output.Message(msg); //Вывод приглашения на ввод
                    string input = Console.ReadLine(); //Считывание строки с клавиатуры
                    result = Convert.ToInt32(input); //Попытка парсинга строки в число
                }
                catch (FormatException) //Если было сгенерировано исключение
                {
                    Output.ErrorMessage("Неверный формат ввода\n"); //Вывод сообщения об ошибке
                    ok = false;
                }
            } while (!ok);

            return result; //Возврат результата
        }

        public static int Integer(string msg, params int[] nonValidValues)
        {
            int result = 0;
            bool ok;

            do
            {
                try
                {
                    ok = true;
                    Output.Message(msg);
                    string input = Console.ReadLine();
                    result = Convert.ToInt32(input);
                    foreach (int value in nonValidValues) ok = result != value && ok;
                }
                catch (FormatException)
                {
                    Output.ErrorMessage("Неверный формат ввода\n");
                    ok = false;
                }
            } while (!ok);

            return result;
        }

        public static int Integer(string msg, string errMsg, int minValue, int maxValue)
        {
            int result = 0;
            bool ok = false;

            do
            {
                try
                {
                    Output.Message(msg); //Вывод приглашения на ввод
                    string input = Console.ReadLine(); //Считывание строки
                    result = Convert.ToInt32(input); //Попытка парсинга

                    if (result >= minValue && result <= maxValue) //Если ввод находится в допустимых границах
                        ok = true; //Парсинг считывание успешно
                    else Output.ErrorMessage($"{errMsg}\n"); //Иначе сообщене о выходе за границы
                }
                catch (FormatException) //Если было сгенерировано исключение
                {
                    Output.ErrorMessage("Неверный формат ввода\n"); //Вывод сообщеня об исключении
                }
            } while (!ok);

            return result;
        }

        public static double Double(string msg)
        {
            double result = 0;
            bool ok;

            do
            {
                try
                {
                    ok = true;
                    Output.Message(msg);
                    string input = Console.ReadLine();
                    result = Convert.ToDouble(input);
                }
                catch (FormatException)
                {
                    Output.ErrorMessage("Неверный формат ввода\n");
                    ok = false;
                }
            } while (!ok);

            return result;
        }

        public static double Double(string msg, params double[] nonValidValues)
        {
            double result = 0;
            bool ok;

            do
            {
                try
                {
                    ok = true;
                    Output.Message(msg);
                    string input = Console.ReadLine();
                    result = Convert.ToDouble(input);
                    foreach (double value in nonValidValues) ok = result != value;
                }
                catch (FormatException)
                {
                    Output.ErrorMessage("Неверный формат ввода\n");
                    ok = false;
                }
            } while (!ok);

            return result;
        }

        public static double Double(string msg, string errMsg, double leftBorder, double rightBorder)
        {
            double result = 0;
            bool ok = false;

            do
            {
                try
                {
                    Output.Message(msg);
                    string input = Console.ReadLine();
                    result = Convert.ToDouble(input);

                    if (result >= leftBorder && result < rightBorder) ok = true;
                    else Output.ErrorMessage($"{errMsg}\n");
                }
                catch (FormatException)
                {
                    Output.ErrorMessage("Неверный формат ввода\n");
                }
            } while (!ok);

            return result;
        }

        public static string String(string msg)
        {
            string result = "";
            do
            {
                Output.Message(msg);
                string input = Console.ReadLine();
                result = Convert.ToString(input);
            } while (System.String.IsNullOrWhiteSpace(result));

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg">Приглашение на ввод</param>
        /// <param name="trueAnsw">"Истинный" ответ</param>
        /// <returns>Вернёт истину, если ввод равен trueAnsw (регистр не важен)</returns>
        public static bool Bool(string msg, string trueAnsw)
        {
            string input = String(msg);

            return (input.ToLower() == trueAnsw.ToLower());
        }

        public static bool Bool(string msg, string[] validAnswers)
        {
            string input = String(msg);

            bool valid = false;

            foreach (string value in validAnswers)
                valid = input.ToLower() == value.ToLower() || valid;

            return valid;
        }
    }
}