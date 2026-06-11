using Raylib_cs;

namespace Tetris
{
    internal static class Program
    {
        public const int WindowWidth = 1280;
        public const int WindowHeight = 720;

        private static void Main(string[] args)
        {
            Raylib.InitWindow(WindowWidth, WindowHeight, "Tetris");
            Raylib.SetAudioStreamBufferSizeDefault(512);
            Raylib.InitAudioDevice();
            Raylib.SetExitKey(KeyboardKey.KEY_NULL);
            Raylib.SetTargetFPS(60);

            LoadEngine.LoadAll();

            while (!Raylib.WindowShouldClose() && GameStateManager.CurrentState != GameState.Exit)
            {
                GameProcess.Update();
                GameProcess.Draw();
            }

            LoadEngine.UnloadAll();
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}
