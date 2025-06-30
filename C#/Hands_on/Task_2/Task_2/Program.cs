using System;

// Step 1: MobilePhone with Delegate and Event
class MobilePhone
{
    public delegate void RingEventHandler();         // Declare delegate
    public event RingEventHandler OnRing;            // Declare event

    public void ReceiveCall()
    {
        Console.WriteLine("Incoming call...");
        OnRing?.Invoke();  // Trigger the event if there are subscribers
    }
}

// Step 2: Subscribers (Handlers)
class RingtonePlayer
{
    public void PlayRingtone()
    {
        Console.WriteLine(" Playing ringtone...");
    }
}

class ScreenDisplay
{
    public void ShowCallerInfo()
    {
        Console.WriteLine("Displaying caller information...");
    }
}

class VibrationMotor
{
    public void Vibrate()
    {
        Console.WriteLine("Phone is vibrating...");
    }
}

// Step 3: Main Program
class Program
{
    static void Main(string[] args)
    {

        MobilePhone phone = new MobilePhone();
        RingtonePlayer ringer = new RingtonePlayer();
        ScreenDisplay screen = new ScreenDisplay();
        VibrationMotor motor = new VibrationMotor();


        phone.OnRing += ringer.PlayRingtone;
        phone.OnRing += screen.ShowCallerInfo;
        phone.OnRing += motor.Vibrate;


        phone.ReceiveCall();

        Console.ReadKey();
    }
}

