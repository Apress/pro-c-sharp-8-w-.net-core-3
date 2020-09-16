using System;
using System.Runtime.CompilerServices;

//[assembly:InternalsVisibleTo("CSharpCarClient")]
namespace CarLibrary
{
    internal class MyInternalClass
    {

    }
    // Represents the state of the engine.
    public enum EngineState
    {
        EngineAlive,
        EngineDead
    }

    // Which type of music player does this car have?
    public enum MusicMedia
    {
        MusicCd,
        MusicTape,
        MusicRadio,
        MusicMp3
    }

    // The abstract base class in the hierarchy.
    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        protected EngineState State = EngineState.EngineAlive;
        public EngineState EngineState => State;
        public abstract void TurboBoost();

        public Car() => Console.WriteLine("CarLibrary Version 2.0!");

        public Car(string name, int maxSpeed, int currentSpeed)
        {
            Console.WriteLine("CarLibrary Version 2.0!");
            PetName = name;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }

        public void TurnOnRadio(bool musicOn, MusicMedia mm)
            => Console.WriteLine(musicOn ? $"Jamming {mm}" : "Quiet time...");
    }
}