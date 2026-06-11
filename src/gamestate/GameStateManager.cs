namespace Tetris
{
    public static class GameStateManager
    {
        public static GameState CurrentState { get; private set; } = GameState.MainMenu;

        public static void ChangeState(GameState nextState)
        {
            if (CurrentState == nextState)
            {
                return;
            }

            CurrentState = nextState;
            AudioManager.HandleStateChanged(nextState);
        }
    }
}
