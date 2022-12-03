/*
    Задача: Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых
    меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры, либо задать на старте
    выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись
    исключительно массивами.

    Примеры:

    ["hello", "2", "world", ":-)"] -> ["2", ":-)"]

    ["1234", "1567", "-2", "computer science"] -> ["-2"]

    ["Russia", "Denmark", "Kazan"] -> []
*/

string?[] chars = CreateArray(GetInputNumber("\nEnter array size: ", IsValidNumber));

Console.WriteLine();
PrintArray(chars);
Console.Write(" -> ");
PrintArray(FilterByLength(chars, 3));
Console.WriteLine();


// ************* methods section ***************

string?[] FilterByLength(string?[] source, int length)
{    
    int count = 0;
    
    string?[] target = new string?[source.Length];

    foreach (var item in source)
    {
        if(item?.Length <= length) 
        {
            target[count++] = item;
        }
    }
    
    Array.Resize(ref target, count);

    return target;
}

string?[] CreateArray(int length)
{
    string?[] array = new string?[length];

    for(int i = 0; i < length; i++)
    {
        Console.Write($"Enter array part {i}: ");
        array[i] = Console.ReadLine();
    }

    return array;
}

void PrintArray(string?[] array)
{
    Console.Write("[");
    
    if(array.Length > 0) 
    {
        for(int i = 0; i < array.Length - 1; i++)
            {
                Console.Write($"\"{array[i]}\", ");
            }
            
            Console.Write($"\"{array[array.Length - 1]}\"");
    }
    
    Console.Write("]");
}

int GetInputNumber(string inputText, IsValid isValid)
{
    string? data;
    
    do
    {
        Console.Write(inputText);
        data = Console.ReadLine();
    }
    while(!isValid(data));

    return Convert.ToInt32(data); ; 
}

bool IsValidNumber(string? data)
{
    if (!(int.TryParse(data, out int number) && number > 0))
    {
        Console.Write("\nError! It's should be natural number\n");
        return false;
    }

    return true;
}

delegate bool IsValid(string? num);