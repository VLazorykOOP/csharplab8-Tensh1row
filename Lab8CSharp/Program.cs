//Exercise 1
using System; 

using System.IO; 

using System.Text.RegularExpressions; 

  

class TextProcessor 

{ 

    private string inputFilePath; 

    private string outputFilePath; 

  

    public TextProcessor(string inputFilePath, string outputFilePath) 

    { 

        this.inputFilePath = inputFilePath; 

        this.outputFilePath = outputFilePath; 

    } 

  

    public void ProcessText() 

    { 

        // Зчитуємо весь текст з вхідного файлу 

        string text = File.ReadAllText(inputFilePath); 

  

        // Використовуємо регулярний вираз для пошуку адрес web-сайтів домена edu.ua 

        string pattern = @"\b\w+://[\w\d.-]+\.edu.ua\b"; 

  

        // Знаходимо всі входження 

        MatchCollection matches = Regex.Matches(text, pattern); 

  

        // Виводимо кількість знайдених адрес 

        Console.WriteLine($"Знайдено {matches.Count} адрес(-ів) домена edu.ua."); 

  

        // Замінюємо адреси на нове значення, використовуючи вказані параметри користувача 

        Console.WriteLine("Введіть нове значення для заміни:"); 

        string newValue = Console.ReadLine(); 

  

        // Замінюємо адреси на нове значення 

        text = Regex.Replace(text, pattern, newValue); 

  

        // Записуємо змінений текст у новий файл 

        File.WriteAllText(outputFilePath, text); 

  

        Console.WriteLine("Операція завершена. Результат записано у новий файл."); 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        // Введення шляхів до вхідного і вихідного файлів 

        Console.WriteLine("Введіть шлях до вхідного файлу:"); 

        string inputFilePath = Console.ReadLine(); 

  

        Console.WriteLine("Введіть шлях до вихідного файлу:"); 

        string outputFilePath = Console.ReadLine(); 

  

        // Створюємо об'єкт класу TextProcessor 

        TextProcessor processor = new TextProcessor(inputFilePath, outputFilePath); 

  

        // Виконуємо обробку тексту 

        processor.ProcessText(); 

    } 

} 



//Exercise 2
using System; 

using System.IO; 

using System.Text.RegularExpressions; 

using System.Linq; 

  

class TextProcessor 

{ 

    private string inputFilePath; 

    private string outputFilePath; 

  

    public TextProcessor(string inputFilePath, string outputFilePath) 

    { 

        this.inputFilePath = inputFilePath; 

        this.outputFilePath = outputFilePath; 

    } 

  

    public void ProcessText() 

    { 

        // Зчитуємо весь текст з вхідного файлу 

        string text = File.ReadAllText(inputFilePath); 

  

        // Регулярний вираз для знаходження українських слів, які починаються з голосної літери 

        string pattern = @"\b[аеиоуюяіїє]\w*\b"; 

  

        // Знаходимо всі входження 

        MatchCollection matches = Regex.Matches(text, pattern); 

  

        // Фільтруємо слова, що починаються на голосну літеру 

        var ukrainianWords = matches.Cast<Match>().Select(match => match.Value); 

  

        // Видаляємо слова з тексту 

        foreach (var word in ukrainianWords) 

        { 

            text = text.Replace(word, ""); 

        } 

  

        // Записуємо змінений текст у новий файл 

        File.WriteAllText(outputFilePath, text); 

  

        Console.WriteLine("Операція завершена. Результат записано у новий файл."); 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        // Введення шляхів до вхідного і вихідного файлів 

        Console.WriteLine("Введіть шлях до вхідного файлу:"); 

        string inputFilePath = Console.ReadLine(); 

  

        Console.WriteLine("Введіть шлях до вихідного файлу:"); 

        string outputFilePath = Console.ReadLine(); 

  

        // Створюємо об'єкт класу TextProcessor 

        TextProcessor processor = new TextProcessor(inputFilePath, outputFilePath); 

  

        // Виконуємо обробку тексту 

        processor.ProcessText(); 

    } 

} 


//Exercise 3

using System; 

using System.IO; 

using System.Linq; 

  

class TextProcessor 

{ 

    private string inputFilePath; 

    private string outputFilePath; 

  

    public TextProcessor(string inputFilePath, string outputFilePath) 

    { 

        this.inputFilePath = inputFilePath; 

        this.outputFilePath = outputFilePath; 

    } 

  

    public void ProcessText() 

    { 

        // Зчитуємо весь текст з вхідного файлу 

        string text = File.ReadAllText(inputFilePath); 

  

        // Розділяємо текст на слова за допомогою пробілів та розділових знаків 

        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', '-', ';', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); 

  

        // Вилучаємо в кожному слові всі попередні входження останньої літери 

        for (int i = 0; i < words.Length; i++) 

        { 

            char lastChar = words[i][words[i].Length - 1]; 

            words[i] = words[i].Replace(lastChar.ToString(), ""); 

        } 

  

        // З'єднуємо слова знову у текст 

        text = string.Join(" ", words); 

  

        // Записуємо змінений текст у новий файл 

        File.WriteAllText(outputFilePath, text); 

  

        Console.WriteLine("Операція завершена. Результат записано у новий файл."); 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        // Введення шляхів до вхідного і вихідного файлів 

        Console.WriteLine("Введіть шлях до вхідного файлу:"); 

        string inputFilePath = Console.ReadLine(); 

  

        Console.WriteLine("Введіть шлях до вихідного файлу:"); 

        string outputFilePath = Console.ReadLine(); 

  

        // Створюємо об'єкт класу TextProcessor 

        TextProcessor processor = new TextProcessor(inputFilePath, outputFilePath); 

  

        // Виконуємо обробку тексту 

        processor.ProcessText(); 

    } 

} 

//Exercise 4
using System; 

using System.IO; 

  

class BinaryFileProcessor 

{ 

    private string inputFilePath; 

    private string outputFilePath; 

  

    public BinaryFileProcessor(string inputFilePath, string outputFilePath) 

    { 

        this.inputFilePath = inputFilePath; 

        this.outputFilePath = outputFilePath; 

    } 

  

    public void ProcessBinaryFile(int min, int max) 

    { 

        using (BinaryReader reader = new BinaryReader(File.Open(inputFilePath, FileMode.Open))) 

        { 

            using (StreamWriter writer = new StreamWriter(outputFilePath)) 

            { 

                while (reader.BaseStream.Position < reader.BaseStream.Length) 

                { 

                    byte number = reader.ReadByte(); // Читаємо наступний байт 

                    int intNumber = Convert.ToInt32(number); // Конвертуємо байт у ціле число 

  

                    // Перевіряємо, чи число попадає у заданий інтервал 

                    if (intNumber >= min && intNumber <= max) 

                    { 

                        // Записуємо число у вихідний файл 

                        writer.WriteLine(intNumber); 

                    } 

                } 

            } 

        } 

    } 

  

    public void DisplayFileContent() 

    { 

        // Виводимо вміст вихідного файлу на екран 

        string[] lines = File.ReadAllLines(outputFilePath); 

        Console.WriteLine("Числа, що попадають у заданий інтервал:"); 

        foreach (string line in lines) 

        { 

            Console.WriteLine(line); 

        } 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        // Введення шляхів до вхідного і вихідного файлів 

        Console.WriteLine("Введіть шлях до вхідного двійкового файлу:"); 

        string inputFilePath = Console.ReadLine(); 

  

        Console.WriteLine("Введіть шлях до вихідного текстового файлу:"); 

        string outputFilePath = Console.ReadLine(); 

  

        // Введення інтервалу 

        Console.WriteLine("Введіть мінімальне значення інтервалу:"); 

        int min = int.Parse(Console.ReadLine()); 

  

        Console.WriteLine("Введіть максимальне значення інтервалу:"); 

        int max = int.Parse(Console.ReadLine()); 

  

        // Створюємо об'єкт класу BinaryFileProcessor 

        BinaryFileProcessor processor = new BinaryFileProcessor(inputFilePath, outputFilePath); 

  

        // Виконуємо обробку двійкового файлу 

        processor.ProcessBinaryFile(min, max); 

  

        // Виводимо вміст вихідного файлу на екран 

        processor.DisplayFileContent(); 

    } 

} 