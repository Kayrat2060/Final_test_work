string CleanText(string text) // функция которая "чистит текст" от лишних пробелов и удаляет все знаки ";" в конце и в начале строки
{
    int m = text.Length;
    for (int i = m-1; i > 0; i--) // цикл в обратном порядке, так как после удаления символа 
    {                             // из строки индекс в следующей итерации не должен повторяться
        if (text[i] == ' ' && text[i-1] == ' ' ) // условие двойного пробела
        text = text.Remove(i, 1);                // удаляем лишний пробел
        else if (text[i] == ';' && text[i-1] == ';' ) // условие двойного знака ";"
        text = text.Remove(i, 1);                     // удаляем лишний знак ";"
    }
    text = text.Trim(new char[] { ' ' , ' ' });      // эта команда удаляет все пробелы в конце  в начале строки
    text = text.Replace(" ;", ";");                  // так удаляем еще лишние пробелы
    text = text.Replace("; ", ";");                  // так удаляем еще лишние пробелы
    text = text.Trim(new char[] { ';' , ';' });      // эта команда удаляет все знаки ";" в конце  в начале строки
    return text;
}

string[] CreateArrayOfStrings(string text)
{
    int lengthArray = 0;              // переменная для определения размера искомого массива
    string[] array = new string[1000]; // задаем масси с заведомо огромной длиной, так как не знаем заранее размер полученного массива
    string tempElement = String.Empty;  // вводим переменную tempElement, в нее будем собирать текущий элемент
    for (int i = 0; i < text.Length; i++) // перебираем в цикле все символы строки
    {
        if (text[i] == ';' && !(text[i-1] == ';')) // это условие того что текущий элемент (строка) закончен
        {                     
            lengthArray++;
            array[lengthArray-1] = tempElement;  // присваиваем текущий элемент массиву
            tempElement = String.Empty;           // и обнуляем нашу временную переменную tempElement
            continue;        
        }
        else if (text[i] == ';' && text[i-1] == ';') // условие того что элемент пустой
            continue;                               // ничего не делаем - переходим на след. шаг
        else if (!(text[i] == ';'))                // условие того что текущий элемент еще не собран
        {            
            tempElement = tempElement + text[i];   // добавляем текущий символ во временную переменную
            if (i < text.Length - 1) continue;     // проверяется что сейчас не последний символ в цикле
        }
        lengthArray++;                             // увеличиваем размерность массива
        array[lengthArray-1] = tempElement;        // добавляем последний элемент в массив
    }
    string[] array2 = new string[lengthArray];     // вводим второй массив с правильной длиной
    for (int j = 0; j < lengthArray; j++)          // для того чтобы ей передать все найденные элементы
    {                                              // из массива с размером 1000
        array2[j] = array[j];
    }
    return array2;
}

string[] SelectsElementsLess4(string[] array)   // функция которая из массива создает массив, элементы которой по длине меньше 4
{
    string[] array2 = new string[array.Length];
    int k = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length < 4)
        {
            array2[k] = array[i];
            k++;
        }
    }
    string[] array3 = new string[k];
    for (int j= 0; j < k; j++)
    {
        array3[j] = array2[j];
    }
    return array3;
}

void PrintArray(string[] array) // функция которая выводит в консоль массив
{
    Console.Write("[");
    if (array.Length > 0)
    {
        Console.Write("\"" + array[0] + "\"");
    }
    for (int i = 1; i < array.Length; i++)
    {
        Console.Write(", \"" + array[i] + "\"");
    }
    Console.WriteLine("]");
}

Console.WriteLine();
Console.WriteLine("Введите любые символы разделенные точкой с запятой (';') и нажмите Enter: "); // запрашиваем у пользователя ввода строки
string textOfConsole = Console.ReadLine();
string cleanText = CleanText(textOfConsole);
string[] arrayString = CreateArrayOfStrings(cleanText); // вызываем функцию которая переводит строку в массив из строк
Console.WriteLine();
PrintArray(arrayString);  // печатаем полученный массив в консоль
Console.WriteLine(" -> ");
string[] arrayWithElementsLess4 = SelectsElementsLess4(arrayString);
PrintArray(arrayWithElementsLess4); // печатаем результирующий массив в консоль
Console.WriteLine();