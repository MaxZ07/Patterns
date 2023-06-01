using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var taskBuilder = new Task.Builder();
            var task = taskBuilder
                .SetName("Task 1")
                .SetDeadLine(new DateTime(2023, 6, 1))
                .SetPerformer(new Performer("Bob"))
                .Build();

            Console.WriteLine($"Задача: {task.Name}, Исполнение: {task.DeadLine}, Исполнитель: {task.Performer.Name}");


            task.AddObserver(new EmailService());
            task.AddObserver(new SlackService());


            task.Name = "TASK #1";
            task.Performer = new Performer("John");
            var duplicateTask = (Task)task.Clone();

            Console.WriteLine($"Задача: {duplicateTask.Name}, Исполнение: {duplicateTask.DeadLine}, Исполнитель: {duplicateTask.Performer.Name}");
        }
    }
}
