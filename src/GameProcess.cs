using Raylib_cs;

namespace Tetris
{
    public static class GameProcess
    {
        public static void Update()
        {
            switch (GameStateManager.CurrentState)
            {
                case GameState.MainMenu:
                    MainMenu.Update();
                    break;

                case GameState.Gameplay:
                    GamePlay.Update();
                    break;

                case GameState.Paused:
                    PauseMenu.Update();
                    break;

                case GameState.GameOver:
                    GameOver.Update();
                    break;
            }

            AudioManager.Update();
        }

        public static void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            switch (GameStateManager.CurrentState)
            {
                case GameState.MainMenu:
                    MainMenu.Draw();
                    break;

                case GameState.Gameplay:
                    Board.Draw();
                    GamePlay.Draw();
                    break;

                case GameState.Paused:
                    Board.Draw();
                    GamePlay.Draw();
                    PauseMenu.Draw();
                    break;

                case GameState.GameOver:
                    GameOver.Draw();
                    break;
            }

            Raylib.EndDrawing();
        }
    }
}
