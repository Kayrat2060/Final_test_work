// логика такая - пользователь вводит в консоль сколько угодно символов через точку с запятой (в пределах разумного)
// программа будет преобразовывать эту строку в массив из отдельных строк

string CleanText(string text)
{
    int m = text.Length;
    for (int i = m-1; i > 0; i--)    
    {
        if (text[i] == ' ' && text[i-1] == ' ' )
        text = text.Remove(i, 1);
        else if (text[i] == ';' && text[i-1] == ';' )
        text = text.Remove(i, 1);
    }
    text = text.Trim(new char[] { ' ' , ' ' }); 
    text = text.Replace(" ;", ";");
    text = text.Replace("; ", ";");
    text = text.Trim(new char[] { ';' , ';' }); 
    return text;
}

string[] CreateArrayOfStrings(string text)
{
    int lengthArray = 0;
    string[] array = new string[1000];
    string tempElement = String.Empty;
    for (int i = 0; i < text.Length; i++)
    {
        if (text[i] == ';' && !(text[i-1] == ';')) 
        {                     
            lengthArray++;
            array[lengthArray-1] = tempElement;
            tempElement = String.Empty;
            continue;        
        }
        else if (text[i] == ';' && text[i-1] == ';')
            continue; 
        else if (!(text[i] == ';'))    
        {            
            tempElement = tempElement + text[i]; 
            if (i < text.Length - 1) continue;  
        }
        lengthArray++;              
        array[lengthArray-1] = tempElement;
    }
    string[] array2 = new string[lengthArray];
    for (int j = 0; j < lengthArray; j++)
    {
        array2[j] = array[j];
    }
    return array2;
}

// string[] CreateArrayOfStrings(string text)
// {
//     int lengthArray = 0;
//     string[] array = new string[1000];
//     string tempElement = String.Empty;
//     for (int i = 0; i < text.Length; i++)
//     {
//         if (text[i] == ';' && !(text[i-1] == ';')) // 2. условие того что текущий символ пробел, а предыдущий не пробел
//         {                                             // это означает что число закончилось на предыдущем шаге
//             lengthArray++;                         // увеличиваем переменную lengthArray на 1,
//                                                     // так как добавился еще один элемент в результирующий массив
//             array[lengthArray-1] = tempElement;  // введем наш полученный элемент в массив
//             tempElement = String.Empty;  // обнулим нашу переменную textNumber, так как в нее теперь будем собирать следующий элемент
//             continue;        // прерываем текущий шаг цикла и переходим на следующий
//         }
//         else if (text[i] == ';' && text[i-1] == ';') continue; // 3. условие того что текущий и предыдущий символы - пробелы
//                                           // означает что ввели лишний пробел - ничего не делаем переходим на след. шаг
//         else if (!(text[i] == ';'))     // 4. условие того что текущ символ не пробел
//         {            
//             tempElement = tempElement + text[i]; // добавляем текущ символ к перем tempElement
//             if (i < text.Length - 1) continue;  // это условие что i не последнее в цикле
//         }
//         lengthArray++;              // 5. увеличиваем переменную lengthArray на 1,
//                                        // так как добавился еще один элемент в массив
//                                           // актуально для последнего элемента в цикле
//         array[lengthArray-1] = tempElement;  // введем наш полученный элемент в массив
//     }
//     string[] array2 = new string[lengthArray]; // введем второй массив для того чтобы в нем бвло правильное количество элементов
//     for (int j = 0; j < lengthArray; j++) // и в цикле присвоим второму массиву все найденные элемнты из начального массива
//     {
//         array2[j] = array[j]; // "почистим" элементы массива от лишних пробелов
//     }
//     return array2; // функция вернет второй массив
// }

string[] SelectsElementsLess4(string[] array)                               // функция которая из массива создает массив, элементы которой по длине меньше 4
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
PrintArray(arrayWithElementsLess4); // печатаем резкльтирующий массив в консоль
Console.WriteLine();