using System;

namespace Test1
{
    public class SlackService : ITaskObserver
    {
        public void OnChanged(Task task)
        {
            Console.WriteLine($"Слаааак!! В вашей задаче изменилось состояние!! `{task.Name} {task.DeadLine} {task.Performer.Name}`");
        }
    }
}
