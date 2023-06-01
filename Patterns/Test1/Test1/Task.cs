using System;
using System.Collections.Generic;

namespace Test1
{
    public class Task : IObservable, ICloneable
    {
        private List<ITaskObserver> _taskObservers;
        private string _name;
        private Performer _performer;
        private DateTime _deadline;

        public string Name { 
            get => _name;
            set {
                _name = value;
                NotifyAllObservers();
            }
        }
        public Performer Performer {
            get => _performer;
            set
            {
                _performer = value;
                NotifyAllObservers();
            }
        }
        public DateTime DeadLine {
            get => _deadline;
            set
            {
                _deadline = value;
                NotifyAllObservers();
            }
        }

        private Task(string name, Performer performer, DateTime deadline)
        {
            _name = name;
            _performer = performer;
            _deadline = deadline;
            _taskObservers = new List<ITaskObserver>();
        }

        private void NotifyAllObservers()
        {
            _taskObservers.ForEach(observer => observer.OnChanged(this));
        }


        public void AddObserver(ITaskObserver observer)
        {
            _taskObservers.Add(observer);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public class Builder : IBuilder<Task>
        {
            private Performer _performer;
            private string _name = String.Empty;
            private DateTime _deadline = new DateTime();

            public Builder SetPerformer(Performer performer) {
                _performer = performer;
                return this;
            }

            public Builder SetName(string name) {
                _name = name;
                return this;
            }

            public Builder SetDeadLine(DateTime deadline) {
                _deadline = deadline;
                return this;
            }

            public Task Build() => new Task(_name, _performer, _deadline);
        }

  
    }
}
