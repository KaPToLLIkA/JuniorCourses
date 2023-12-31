﻿using System.Text;

namespace Collections_Task1
{
    internal class Dictionary
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> wordsDescriptions = new()
            {
                {"инновация", "внедрение нового или улучшенного продукта, услуги или процесса"},
                {"эмпатия", "способность понимать и разделять чувства и переживания других людей"},
                {"функциональность", "способность или качество выполнять определенные функции"},
                {"экосистема", "совокупность взаимосвязанных организмов и среды, в которой они существуют"},
                {"глобализация", "процесс увеличения взаимосвязи и зависимости различных стран и регионов"},
                {"интуиция", "способность понимать что-то без объяснений или логического мышления"},
                {"социализация", "процесс присоединения человека к обществу, приобретения общепринятых норм и ценностей"},
                {"креативность", "способность мыслить и действовать оригинально и новаторски"},
                {"активизация", "процесс увеличения активности или энергии в определенной сфере"},
                {"эффективность", "способность достигать желаемого результата с минимальными затратами"},
                {"акцент", "особое ударение, выделение или подчеркивание чего-либо"},
                {"благодарность", "признательность, чувство благодарности"},
                {"вдохновение", "состояние, когда появляется резкая заинтересованность и желание действовать"},
                {"гибкость", "способность легко приспосабливаться, изменяться или подстраиваться под новые условия"},
                {"доброта", "состояние искреннего желания помощи и сострадания к другим людям"},
                {"жизнерадостный", "полный энергии, оптимизма и радости по отношению к жизни"},
                {"забота", "проявление заботы и внимания к кому-либо или чему-либо"},
                {"интуитивный", "связанный с интуицией, понимание без объяснений или логического мышления"},
                {"компетентность", "способность профессионально или квалифицированно выполнять задачи"},
                {"лидерство", "способность вести и вдохновлять других к достижению общих целей"},
            };

            bool isRunning = true;

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (isRunning)
            {
                Console.WriteLine("Введите слово:");
                string word = Console.ReadLine();
                string lowerWord = word.ToLower();

                if (wordsDescriptions.ContainsKey(lowerWord))
                {
                    Console.WriteLine($"Определение слова: {wordsDescriptions[lowerWord]}");
                }
                else
                {
                    Console.WriteLine("Такого слова у нас нет...");
                }
            }
        }
    }
}
