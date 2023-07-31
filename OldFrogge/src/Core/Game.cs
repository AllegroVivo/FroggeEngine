using System;

using Frogge.Systems;

namespace Frogge.Core;

public class Game
{
    private Boolean _isRunning = true;
    
    private readonly Time _clock;
    private readonly Logger _logger;
    private readonly EventSystem _eventSystem;
    private readonly RenderingSystem _renderer;

    public Game()
    {
        _clock = new Time();
        _logger = new Logger();
        _eventSystem = new EventSystem();
        _renderer = new RenderingSystem();
    }

    public void Run()
    {
        _logger.Log("Game is running...");
        
        Initialize();

        _eventSystem.DispatchEvent("GameStarted", 0);
        
        while (_isRunning)
        {
            Update();
            
            Render();

            _clock.Tick(30);
        }
        
        Cleanup();
        
        _logger.Log("Game is shutting down...");
    }
    
    private void Initialize()
    {
    }

    private void Update()
    {
        Console.WriteLine("Updating...");
    }

    private void Render()
    {
        _renderer.Clear();
        // --------------------
        // Draw stuff here
        // --------------------
        _renderer.Present();
    }
    
    private void Cleanup()
    {
        _renderer.Dispose();
    }

    private void HandleUpdate(String eventName, Object data)
    {
        // This method will be called whenever TriggerEvent is called on eventSystem
        Console.WriteLine($"Event triggered: {eventName} {data}");
    }
}