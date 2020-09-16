using System;

namespace ApplyingAttributes
{
    [Obsolete]
    // This class can be saved to disk.
    [Serializable]
    public class Motorcycle
    {
        // However, this field will not be persisted.
        [NonSerialized]
        float weightOfCurrentPassengers;
        // These fields are still serializable.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}