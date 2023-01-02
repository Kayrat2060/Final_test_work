# Итоговая проверочная работа по первому блоку обучения на программе Разработчик

## Описание
Данная программа из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам.
Первоначальный массив вводится с клавиатуры. После запуска программы, она запрашивает у пользователя ввода данных. Пользователь вводит с клавиатуры любые символы, слова или числа в одну строку, разделяя их точкой с запятой (`";"`), и нажимает `Enter`. После чего программа выводит на экран массив полученный из введенной строки и массив полученный из предыдущего массива, но в которую входят лишь элементы, длина которых меньше, либо равна 3 символам.
Например: 

```
Введите любые символы разделенные точкой с запятой (";") и нажмите Enter: 
1234; 1567; -2; computer science

[“1234”, “1567”, “-2”, “computer science”]
 → 
[“-2”]
```

В качестве разделителя был выбран знак `";"`. Строки состоящие из 0 символов или состоящие из пробела/ов не входят в итоговый массив.

## Требования
- Должен быть аккаунт на *[GitHub](github.com)*

### На рабочем месте клиента должны быть установлены:
- *[Visual Studio Code](https://code.visualstudio.com/download)*
- Расширение *C# for Visual Studio Code (powered by OmniSharp)*

## Сборка и запуск примера
### Для использования программы необходимо:
- Создать на локальном компьютере папку, например "Examples"
- Открыть эту папку "Examples" в **Visual Studio Code**
- Вызвать терминал для этой папки
- В терминале запустить инициализацию - ***git init***
- Войти в свой аккаунт на GitHub
- Сделать fork репозитория https://github.com/Kayrat2060/Final_test_work
- Далее сделать ***git clone*** уже свого репозитория на свой локальный компьютер.
- Далее запускаем терминал для папки "Exx01"
- Пишем в терминале: ***dotnet run*** и нажимаем кнопку `Enter`
- Программа запущена, необходимо следовать указаниям в косоли

```
Примеры:
[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
[“1234”, “1567”, “-2”, “computer science”] → [“-2”]
[“Russia”, “Denmark”, “Kazan”] → []
```
## Полный код программы и некоторые пояснения
### Код программы:
``` 
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

string[] SelectsElementsLess4(string[] array)
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
 
void PrintArray(string[] array)
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
Console.WriteLine("Введите любые символы разделенные точкой с запятой (';') и нажмите Enter: ");
string textOfConsole = Console.ReadLine();
string cleanText = CleanText(textOfConsole);
string[] arrayString = CreateArrayOfStrings(cleanText);
Console.WriteLine();
PrintArray(arrayString);
Console.WriteLine(" -> ");
string[] arrayWithElementsLess4 = SelectsElementsLess4(arrayString);
PrintArray(arrayWithElementsLess4);
Console.WriteLine();
```
### Программа состоит из 4 методов:
- ***CleanText()***
- ***CreateArrayOfStrings()***
- ***SelectsElementsLess4()***
- ***PrintArray()***

1. Метод _**CleanText()**_ принимает переменную строкового типа. Это метод "чистит" текст от ненужных пробелов, и "чистит" от лишних знаков `";"` в начале и в конце строки. На выходе метод возвращает переменную строкового типа.
2. Метод ***CreateArrayOfStrings()*** принимает переменную строкового типа и возвращает массив строкового типа. То есть массив состоит из строк исходной строки, в которой в качестве разделителя присутствует знак `";"`. То есть все, что находится до, между, и после `";"`, будут отдельными элементами массива, кроме элементов с длиной 0.
3. Метод ***SelectsElementsLess4()*** принимает на вход массив, элементами которого являются строки. И возвращает так же массив из строк, состоящий из элементов входящего массива, длина которых меньше 4.
4. Метод ***PrintArray()*** принимает на вход массив из строк, не возвращая результата, лишь выводит массив на экран.

### Таким образом программа осуществляет следующий алгоритм:
- После запуска программы, в консоль выходит сообщение для пользователя - ***"Введите любые символы разделенные точкой с запятой (`";"`) и нажмите Enter: "***, за это отвечает строка:
```
Console.WriteLine("Введите любые символы разделенные точкой с запятой (";") и нажмите Enter: ");
```
- После нажатия на `Enter` программа считывает, то что ввел пользователь и присваивает ее переменной ***textOfConsole***, за это отвечает строка:
```
string textOfConsole = Console.ReadLine();
```
- После чего идет вызов метода ***CleanText()*** с переменной ***textOfConsole***. Результат присваивается переменной ***cleanText***. За это отвечает строка:
```
string cleanText = CleanText(textOfConsole);
```
- Полученную переменную ***cleanText*** ("подчищенный текст") передаем методу ***CreateArrayOfStrings()*** и результат присваиваем массиву ***arrayString*** строкового типа:
```
string[] arrayString = CreateArrayOfStrings(cleanText);
```
- Выводим полученный массив на экран:
```
PrintArray(arrayString);
```
- На следующей строчке вставим стрелочку ***"->"*** :
```
Console.WriteLine(" -> ");
```
- И наконец вызываем наш клчевой метод ***SelectsElementsLess4()***, который из предыдущего массива ***arrayString*** выбирает элементы, длина которых меньше или равна 3 символам. И создает из этих элементов новый массив, который присвоим переменной ***arrayWithElementsLess4***:
```
string[] arrayWithElementsLess4 = SelectsElementsLess4(arrayString);
```
- Ну и конечно же выводим наш результирующий массив ***arrayWithElementsLess4*** на экран:
```
PrintArray(arrayWithElementsLess4);
```
- End
