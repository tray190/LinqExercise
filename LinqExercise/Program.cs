﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());

            //Order numbers in ascending order and decsending order. Print each to console.
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();


            //Print to the console only the numbers greater than 6
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));


            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var ordernumbers = numbers.OrderBy(x => x);

            foreach (var num in ordernumbers.Take(4)) 
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 27;
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            employees.Where(employee => employee.FirstName[0] == 'C' || employee.FirstName[0] == 'S').ToList().ForEach(x => Console.WriteLine(x.FullName));
            Console.WriteLine();
            //Order this in acesnding order by FirstName.
            employees.Where(employee => employee.FirstName[0] == 'C' || employee.FirstName[0] == 'S').OrderBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine(x.FullName));
            Console.WriteLine();
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            employees.Where(x => x.Age > 26).ToList().ForEach(x => Console.WriteLine($"name:{ x.FullName }\n" +
                                                                                    $"Age:{x.Age}"));
            Console.WriteLine();
            Console.WriteLine("*******************");
            //Order this by Age first and then by FirstName in the same result.
            employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine($"name:{ x.FullName }\n" +
                                                                                    $"Age:{x.Age}"));
            Console.WriteLine();
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var sumYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            int sum = 0;
            int count = 0;
            double average = 0;

            foreach (var employee in sumYOE)
            {
                sum += employee.YearsOfExperience;
                count++;
            }
            average = sum / count;

            Console.WriteLine($"total years of experience: {sum}");
            Console.WriteLine($"average years of experience: {average}");

            //Add an employee to the end of the list without using employees.Add()
            employees.Append(new Employee("Tracy", "Bell", 27, 1)); 


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
