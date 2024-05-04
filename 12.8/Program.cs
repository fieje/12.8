using System;
using System.Collections.Generic;

class Train
{
    public int TrainNumber { get; set; }
    public DateTime ArrivalTime { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<Train> trainSchedule = new LinkedList<Train>();

        trainSchedule.AddLast(new Train { TrainNumber = 101, ArrivalTime = new DateTime(2024, 5, 4, 10, 0, 0) });
        trainSchedule.AddLast(new Train { TrainNumber = 102, ArrivalTime = new DateTime(2024, 5, 4, 11, 30, 0) });
        trainSchedule.AddLast(new Train { TrainNumber = 103, ArrivalTime = new DateTime(2024, 5, 4, 13, 0, 0) });

        Console.WriteLine("Enter start time (hh:mm): ");
        TimeSpan startTime = TimeSpan.Parse(Console.ReadLine());
        Console.WriteLine("Enter end time (hh:mm): ");
        TimeSpan endTime = TimeSpan.Parse(Console.ReadLine());

        LinkedList<Train> trainsInTimeRange = FindTrainsInTimeRange(trainSchedule, startTime, endTime);

        Console.WriteLine("\nInitial train schedule:");
        PrintTrainSchedule(trainSchedule);

        Console.WriteLine("\nTrains arriving in the specified time range along with platform numbers:");
        PrintTrainScheduleWithPlatform(trainsInTimeRange);

        Console.ReadLine();
    }

    static LinkedList<Train> FindTrainsInTimeRange(LinkedList<Train> trainSchedule, TimeSpan startTime, TimeSpan endTime)
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

    static void PrintTrainSchedule(LinkedList<Train> trainSchedule)
    {
        foreach (Train train in trainSchedule)
        {
            Console.WriteLine($"Train number {train.TrainNumber}, arrival time {train.ArrivalTime}");
        }
    }

    static void PrintTrainScheduleWithPlatform(LinkedList<Train> trainSchedule)
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
