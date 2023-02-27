// See using System;

public class Program
{
    public static void Main()
    {
        // Створення масиву з трьох делегатів, які повертають випадкове ціле число
        Func<int>[] delegates = new Func<int>[] {
            () => new Random().Next(1, 10),
            () => new Random().Next(1, 10),
            () => new Random().Next(1, 10)
        };

        // Створення анонімного методу, який приймає масив делегатів та повертає середнє арифметичне значення,
        // повернене методами, які повідомлені з делегатів у масиві
        Func<Func<int>[], double> averageDelegateValues = delegate (Func<int>[] funcs) {
            double sum = 0;
            foreach (var func in funcs)
            {
                sum += func();
            }
            return sum / funcs.Length;
        };

        // Виклик анонімного методу та вивід результату
        double averageValue = averageDelegateValues(delegates);
        Console.WriteLine($"Середнє арифметичне значення: {averageValue}");
    }
}
