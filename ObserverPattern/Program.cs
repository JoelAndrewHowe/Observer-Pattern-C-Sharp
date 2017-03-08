using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        /// <summary>
        /// Observers will watch a 'Subject' class. They Observe any changes made to the subject, that will trigger a function here. For this example, it has one main function called 'Update'. This function is triggered by the Subject.
        /// </summary>
        public abstract class Observer
        {
            public abstract void Update();
        }
        /// <summary>
        /// The subject is the class being monitored. This would be your base calss that will hold the temperature, waiting for it to be updated.
        /// </summary>
        public abstract class Subject
        {
            private List<Observer> observers = new List<Observer>();

            /// <summary>
            /// This will add an observer to the subject. This will mean that, once added, it will begin monitoring any changes to the subject
            /// </summary>
            public void AddObserver(Observer _observer)
            {
                observers.Add(_observer);
            }

            /// <summary>
            /// This will remove an observer from the subject, meaning it will no longer monitor the Subject
            /// </summary>
            public void RemoveObserver(Observer _observer)
            {
                observers.Remove(_observer);
            }

            public void Notify()
            {
                foreach (Observer o in observers)
                {
                    o.Update();
                }
            }
        }



        /// <summary>
        /// This is a 'Concrete Class'. This is an actual implementation of a subject.
        /// </summary>
        public class TemperatureSubject : Subject
        {
            private float _currentTemp;

            public float currentTemp
            {
                get { return _currentTemp;  }
            }

            public void setTemp(float theVal)
            {
                _currentTemp = theVal;
                this.Notify();
            }

        }

        public class TemperatureObserver : Observer
        {
            private TemperatureSubject _subject;

            public TemperatureObserver(ref TemperatureSubject theSubject)
            {
                _subject = theSubject;
            }
            public override void Update()
            {
                Console.WriteLine("The temperature is " + _subject.currentTemp.ToString());
            }

        }

        public class TemperatureObserver2 : Observer
        {
            private TemperatureSubject _subject;

            public TemperatureObserver2(ref TemperatureSubject theSubject)
            {
                _subject = theSubject;
            }
            public override void Update()
            {
                Console.WriteLine("The temperature is " + _subject.currentTemp.ToString() + ". This is the second observer telling you!");
            }

        }



        /// <summary>
        /// Observer Pattern code examples available @ http://www.dofactory.com/net/observer-design-pattern
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        { 
            TemperatureSubject theSubject = new TemperatureSubject();
            theSubject.AddObserver(new TemperatureObserver(ref theSubject));
            theSubject.AddObserver(new TemperatureObserver2(ref theSubject));
            theSubject.setTemp(20.2f);

            Console.ReadLine();

        }
    }
}
