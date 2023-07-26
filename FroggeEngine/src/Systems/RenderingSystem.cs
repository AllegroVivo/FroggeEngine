using System;
using SDL2;

namespace Frogge.Systems;

public class RenderingSystem
{
    private IntPtr _window;
    private IntPtr _renderer;

    public RenderingSystem(String title, Int32 windowWidth, Int32 windowHeight)
    {
        SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

        _window = SDL.SDL_CreateWindow(
            title,
            SDL.SDL_WINDOWPOS_CENTERED,
            SDL.SDL_WINDOWPOS_CENTERED,
            windowWidth, windowHeight,
            SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
        );
        _renderer = SDL.SDL_CreateRenderer(_window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
    }

    public void Clear()
    {
        SDL.SDL_SetRenderDrawColor(_renderer, 255, 255, 255, 255);
        SDL.SDL_RenderClear(_renderer);
    }

    public void Present()
    {
        SDL.SDL_RenderPresent(_renderer);
    }

    public void Dispose()
    {
        SDL.SDL_DestroyRenderer(_renderer);
        SDL.SDL_DestroyWindow(_window);
        SDL.SDL_Quit();
    }
}