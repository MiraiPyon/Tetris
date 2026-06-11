using Raylib_cs;

namespace Tetris
{
    public static class AudioManager
    {
        private enum MusicTrack
        {
            None,
            MainMenu,
            Gameplay
        }

        private static Music mainMenuMusic;
        private static Music gameplayMusic;
        private static Sound clickSound;
        private static Sound dropSound;
        private static Sound gameOverSound;
        private static Sound holdSound;
        private static Sound noHoldSound;
        private static Sound lineClearSound;
        private static Sound rotationSound;
        private static Sound tetrisClearSound;
        private static MusicTrack currentTrack = MusicTrack.None;
        private static bool isLoaded;

        public static void LoadAll()
        {
            mainMenuMusic = Raylib.LoadMusicStream("assets/music/Main Menu.mp3");
            gameplayMusic = Raylib.LoadMusicStream("assets/music/Type B.mp3");
            mainMenuMusic.Looping = true;
            gameplayMusic.Looping = true;

            clickSound = Raylib.LoadSound("assets/sound/click.mp3");
            dropSound = Raylib.LoadSound("assets/sound/drop.mp3");
            gameOverSound = Raylib.LoadSound("assets/sound/game_over.mp3");
            holdSound = Raylib.LoadSound("assets/sound/hold.mp3");
            noHoldSound = Raylib.LoadSound("assets/sound/no_hold.mp3");
            lineClearSound = Raylib.LoadSound("assets/sound/line_clear.mp3");
            rotationSound = Raylib.LoadSound("assets/sound/rotation.mp3");
            tetrisClearSound = Raylib.LoadSound("assets/sound/tetris_clear.mp3");

            Raylib.SetMusicVolume(mainMenuMusic, 0.65f);
            Raylib.SetMusicVolume(gameplayMusic, 0.55f);
            SetSoundVolumes();
            isLoaded = true;
            HandleStateChanged(GameStateManager.CurrentState);
        }

        public static void Update()
        {
            switch (currentTrack)
            {
                case MusicTrack.MainMenu:
                    Raylib.UpdateMusicStream(mainMenuMusic);
                    break;

                case MusicTrack.Gameplay:
                    Raylib.UpdateMusicStream(gameplayMusic);
                    break;
            }
        }

        public static void UnloadAll()
        {
            StopMusic();
            Raylib.UnloadMusicStream(mainMenuMusic);
            Raylib.UnloadMusicStream(gameplayMusic);
            Raylib.UnloadSound(clickSound);
            Raylib.UnloadSound(dropSound);
            Raylib.UnloadSound(gameOverSound);
            Raylib.UnloadSound(holdSound);
            Raylib.UnloadSound(noHoldSound);
            Raylib.UnloadSound(lineClearSound);
            Raylib.UnloadSound(rotationSound);
            Raylib.UnloadSound(tetrisClearSound);
            isLoaded = false;
        }

        public static void PlayClick()
        {
            PlaySoundImmediate(clickSound);
        }

        public static void PlayDrop()
        {
            PlaySoundImmediate(dropSound);
        }

        public static void PlayRotation()
        {
            PlaySoundImmediate(rotationSound);
        }

        public static void PlayLineClear(int clearedLines)
        {
            PlaySoundImmediate(clearedLines >= 4 ? tetrisClearSound : lineClearSound);
        }

        public static void PlayHold()
        {
            PlaySoundImmediate(holdSound);
        }

        public static void PlayNoHold()
        {
            PlaySoundImmediate(noHoldSound);
        }

        public static void HandleStateChanged(GameState state)
        {
            if (!isLoaded)
            {
                return;
            }

            switch (state)
            {
                case GameState.MainMenu:
                    Raylib.StopSound(gameOverSound);
                    PlayMusic(MusicTrack.MainMenu);
                    break;

                case GameState.Gameplay:
                case GameState.Paused:
                    Raylib.StopSound(gameOverSound);
                    PlayMusic(MusicTrack.Gameplay);
                    break;

                case GameState.GameOver:
                    StopMusic();
                    Raylib.StopSound(gameOverSound);
                    Raylib.PlaySound(gameOverSound);
                    break;

                case GameState.Exit:
                    StopMusic();
                    break;
            }
        }

        private static void PlayMusic(MusicTrack track)
        {
            if (currentTrack == track)
            {
                return;
            }

            StopMusic();
            currentTrack = track;

            switch (track)
            {
                case MusicTrack.MainMenu:
                    Raylib.PlayMusicStream(mainMenuMusic);
                    break;

                case MusicTrack.Gameplay:
                    Raylib.PlayMusicStream(gameplayMusic);
                    break;
            }
        }

        private static void StopMusic()
        {
            if (currentTrack == MusicTrack.MainMenu)
            {
                Raylib.StopMusicStream(mainMenuMusic);
            }
            else if (currentTrack == MusicTrack.Gameplay)
            {
                Raylib.StopMusicStream(gameplayMusic);
            }

            currentTrack = MusicTrack.None;
        }

        private static void SetSoundVolumes()
        {
            Raylib.SetSoundVolume(clickSound, 0.7f);
            Raylib.SetSoundVolume(dropSound, 0.75f);
            Raylib.SetSoundVolume(gameOverSound, 0.9f);
            Raylib.SetSoundVolume(holdSound, 0.75f);
            Raylib.SetSoundVolume(noHoldSound, 0.75f);
            Raylib.SetSoundVolume(lineClearSound, 0.85f);
            Raylib.SetSoundVolume(rotationSound, 0.7f);
            Raylib.SetSoundVolume(tetrisClearSound, 0.9f);
        }

        private static void PlaySoundImmediate(Sound sound)
        {
            Raylib.StopSound(sound);
            Raylib.PlaySound(sound);
        }
    }
}
