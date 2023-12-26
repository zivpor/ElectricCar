using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectricCar
{
    public class Battery
    {
        const int MAX_CAPACITY = 1000;
        private static Random r = new Random();
        //Add events to the class to notify upon threshhold reached and shut down!
        #region events
        public event EventHandler ReachThreshold;
        public event EventHandler ShutDown;
        #endregion
        private int Threshold { get; }
        public int Capacity { get; set; }
        public int Percent
        {
            get
            {
                return 100 * Capacity / MAX_CAPACITY;
            }
        }
        public Battery()
        {
            Capacity = MAX_CAPACITY;
            Threshold = 400;
        }
        public void Usage()
        {
            if (Capacity > 0)
            {
                Capacity -= r.Next(50, 150);
                //Add calls to the events based on the capacity and threshhold
                if (Capacity < this.Threshold)
                {
                    OnLowBatery();
                }
            }
            OnShutDown();
            #region Fire Events
            #endregion
        }
        private void OnLowBatery()
        {
            ReachThreshold?.Invoke(this, new EventArgs());
        }
        private void OnShutDown()
        {
            ShutDown?.Invoke(this, new EventArgs());
        }
    }
    class ElectricCar
    {
        public Battery Bat { get; set; }
        private int id;
        //Add event to notify when the car is shut down
        public event EventHandler OnShutDown;
        public ElectricCar(int id)
        {
            this.id = id;
            Bat = new Battery();
            #region Register to battery events
            Bat.ReachThreshold += LowBateryMessege;
            #endregion

        }
        public void StartEngine()
        {
            while (Bat.Capacity > 0)
            {
                Console.WriteLine($"{this} {Bat.Percent}% Thread: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
                Bat.Usage();
            }
        }
        private void OnOnShutDown()
        {
            OnShutDown?.Invoke(this, new EventArgs());
        }
        //Add code to Define and implement the battery event implementations
        #region events implementation
        public void LowBateryMessege(object sender, EventArgs e)
        {
            Console.WriteLine("low batery");
        }
        #endregion

        public override string ToString()
        {
            return $"Car: {id}";
        }
        public void OnShutDownMessage() 
        {
            Console.WriteLine("Shut Down");
        }



    }

}
