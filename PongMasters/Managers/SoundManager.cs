using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

public static class SoundManager
{
    private static WindowsMediaPlayer sfxPlayer = new WindowsMediaPlayer();
    private static WindowsMediaPlayer specialSfxPlayer = new WindowsMediaPlayer();

    public static void PlaySoundEffect(string soundFile)
    {
        sfxPlayer.URL = soundFile;
        sfxPlayer.settings.volume = 33;
        sfxPlayer.controls.play();
    }

    public static void PlaySpecialSoundEffect(string soundFile)
    {
        specialSfxPlayer.URL = soundFile;
        specialSfxPlayer.settings.volume = 33;
        specialSfxPlayer.controls.play();
    }

    public static void StopSoundEffect()
    {
        sfxPlayer.controls.stop();
    }

    public static void StopSpecialSoundEffect()
    {
        specialSfxPlayer.controls.stop();
    }

    public static void DisposeAll()
    {
        DisposePlayer(sfxPlayer);
        DisposePlayer(specialSfxPlayer);
    }

    private static void DisposePlayer(WindowsMediaPlayer player)
    {
        if (player != null)
        {
            player.controls.stop();
            player.close();
        }
    }
}
