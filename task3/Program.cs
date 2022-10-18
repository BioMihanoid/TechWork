using System;
using System.Collections.Generic;

static class Program
{
    /// <summary>
    /// <para> Отсчитать несколько элементов с конца </para>
    /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
    /// </summary> 
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
    /// <returns></returns>
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        List<(T item, int? tail)> res = new List<(T item, int? tail)> ();

        if (tailLength <= 0)
        {
            //один проход чтобы перезаполнить массив
            foreach (var item in enumerable)
                res.Add((item, null));
        }
        else
        {
            int len = enumerable.Count(); //первый проход по массиву чтобы узнать длину
            int? tailIndex = tailLength - 1;
            int i = 0;
            //второй проход чтобы его заполнить
            foreach (var item in enumerable)
            {
                if (i + tailLength >= len)
                    res.Add((item, tailIndex--));
                else
                    res.Add((item, null));
                i++;
            }
        }
        return res;
    }

    //в задаче не определено поведение функции при отрицательных значениях, я интерпретировал это как что не будет ни одного
    //значения отбираться, но с другой стороны можно бы было сделать логику присваивания индексов начальным элементам.
    //касательно вопроса можно ли за один цикл. нет, только в случае с нулём, ибо там просто переприсваивание будет, а для
    //раставления индексов с конца надо знать конец. Это 1-2 цикла в зависимости от условия, >0 или <=0

    
    static void Main(string[] args)
    {
        int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        var res = array.EnumerateFromTail(5);
        foreach (var el in res)
            Console.WriteLine(el);
    }
}