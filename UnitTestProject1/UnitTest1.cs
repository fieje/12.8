using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFindTrainsInTimeRange()
        {
            LinkedList<Train> trainSchedule = new LinkedList<Train>();
            trainSchedule.AddLast(new Train { TrainNumber = 101, ArrivalTime = new DateTime(2024, 5, 4, 10, 0, 0) });
            trainSchedule.AddLast(new Train { TrainNumber = 102, ArrivalTime = new DateTime(2024, 5, 4, 11, 30, 0) });
            trainSchedule.AddLast(new Train { TrainNumber = 103, ArrivalTime = new DateTime(2024, 5, 4, 13, 0, 0) });

            TimeSpan startTime = new TimeSpan(9, 0, 0); 
            TimeSpan endTime = new TimeSpan(12, 0, 0);  

            LinkedList<Train> trainsInTimeRange = Program.FindTrainsInTimeRange(trainSchedule, startTime, endTime);

            Assert.AreEqual(2, trainsInTimeRange.Count); 
            foreach (Train train in trainsInTimeRange)
            {
                Assert.IsTrue(train.ArrivalTime.TimeOfDay >= startTime && train.ArrivalTime.TimeOfDay <= endTime); 
            }
        }
    }

    public class Train
    {
        public int TrainNumber { get; set; }
        public DateTime ArrivalTime { get; set; }
    }

    public class Program
    {
        public static LinkedList<Train> FindTrainsInTimeRange(LinkedList<Train> trainSchedule, TimeSpan startTime, TimeSpan endTime)
        {
            LinkedList<Train> trainsInTimeRange = new LinkedList<Train>();

            foreach (Train train in trainSchedule)
            {
                if (train.ArrivalTime.TimeOfDay >= startTime && train.ArrivalTime.TimeOfDay <= endTime)
                {
                    trainsInTimeRange.AddLast(train);
                }
            }

            return trainsInTimeRange;
        }

        public static void PrintTrainSchedule(LinkedList<Train> trainSchedule)
        {
            foreach (Train train in trainSchedule)
            {
                Console.WriteLine($"Train number {train.TrainNumber}, arrival time {train.ArrivalTime}");
            }
        }

        public static void PrintTrainScheduleWithPlatform(LinkedList<Train> trainSchedule)
        {
            foreach (Train train in trainSchedule)
            {
                Console.WriteLine($"Train number {train.TrainNumber}, arrival time {train.ArrivalTime}, platform: {GetPlatformNumber(train.TrainNumber)}");
            }
        }

        static int GetPlatformNumber(int trainNumber)
        {
            return trainNumber % 3 + 1;
        }
    }
}
