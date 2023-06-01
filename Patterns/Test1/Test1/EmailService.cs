using System;

namespace Test1
{
    public class EmailService : ITaskObserver
    {
        public void OnChanged(Task task)
        {
            Console.WriteLine($"Вам почта!! В вашей задаче изменилось состояние!! `{task.Name} {task.DeadLine} {task.Performer.Name}`");
        }
    }
}
