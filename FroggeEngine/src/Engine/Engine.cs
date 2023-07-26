using System;

namespace Frogge.Engine;

public class Engine
{
    private Boolean _initialized;
    private event Action OnQuit;
    
    public Boolean IsInitialized() => _initialized;

    public void Init()
    {
        // Initialize input systems
        // Input.Init();
        
        // Initialize event system
        // EventSystem.Init();
        
        // Initialize graphics systems
        // Graphics.Init();
        
        // Etc...
        
        _initialized = true;
    }
    
    public void Quit()
    {
        // Quit input systems
        // Input.Quit();
        
        // Quit event system
        // EventSystem.Quit();
        
        // Quit graphics systems
        // Graphics.Quit();
        
        // Etc...
        
        OnQuit?.Invoke();
        
        _initialized = false;
    }

    public void RegisterQuit(Action callback)
    {
        OnQuit += callback;
    }
    
    public void UnregisterQuit(Action callback)
    {
        OnQuit -= callback;
    }
}