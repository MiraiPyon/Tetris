namespace Tetris
{
    public static class LoadEngine
    {
        public static void LoadAll()
        {
            BoardManager.LoadAll();
            MainMenuManager.LoadAll();
            BlockManager.LoadAll();
        }
        public static void UnloadAll()
        {
            BoardManager.UnloadAll();
            MainMenuManager.UnloadAll();
            BlockManager.UnloadAll();
        }
    }
}