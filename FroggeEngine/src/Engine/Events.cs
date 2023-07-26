using System;

namespace Frogge.Engine;

public class EventSystem
{
    // Define a delegate type for event handlers
    public delegate void EventHandler(String eventName, Object data);

    public event EventHandler OnEvent;
    
    // Method to trigger an event
    public void DispatchEvent(String eventName, Object data)
    {
        OnEvent?.Invoke(eventName, data);
    }
}