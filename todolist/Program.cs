using System;
using System.Collections.Generic;
using System.IO;

class ToDoListApp
{
    static string filePath = "tasks.txt";
    static List<string> tasks = new List<string>();

    static void Main()
    {
        LoadTasks();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======= TO-DO LIST =======");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    MarkTaskCompleted();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    SaveTasks();
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            tasks = new List<string>(File.ReadAllLines(filePath));
        }
    }

    static void SaveTasks()
    {
        File.WriteAllLines(filePath, tasks);
    }

    static void ViewTasks()
    {
        Console.Clear();
        Console.WriteLine("======= TASK LIST =======");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    static void AddTask()
    {
        Console.Clear();
        Console.Write("Enter the task description: ");
        string task = Console.ReadLine();
        tasks.Add("[ ] " + task);
        Console.WriteLine("Task added successfully!");
        SaveTasks();
        System.Threading.Thread.Sleep(1000);
    }

    static void MarkTaskCompleted()
    {
        ViewTasks();
        Console.Write("Enter the task number to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks[index - 1] = tasks[index - 1].Replace("[ ]", "[✓]");
            Console.WriteLine("Task marked as completed!");
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
        System.Threading.Thread.Sleep(1000);
    }

    static void DeleteTask()
    {
        ViewTasks();
        Console.Write("Enter the task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Task deleted successfully!");
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
        System.Threading.Thread.Sleep(1000);
    }
}
