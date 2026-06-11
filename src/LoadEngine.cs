namespace Tetris
{
    public static class LoadEngine
    {
        public static void LoadAll()
        {
            AudioManager.LoadAll();
            BoardManager.LoadAll();
            MainMenuManager.LoadAll();
            BlockManager.LoadAll();
        }

        public static void UnloadAll()
        {
            BlockManager.UnloadAll();
            MainMenuManager.UnloadAll();
            BoardManager.UnloadAll();
            AudioManager.UnloadAll();
        }
    }
}
