using Assets.Script;
using System.Collections.Generic;


public static class FakeSaveSystem
{
    //Gameplay
    public static int NumberOfPlayers = 4;
    public static float AnswareTime = 90.0f;
    public static float ChallangeTime = 150.0f;
    //Volume
    public static bool IsMute = false;
    public static float MasterVolume = 1f;
    public static float MusicVolume = 0.6f;
    public static float FxVolume = 1f;
    public static float UIVolume = 0.8f;
    //Graphics
    public static int GraphicsQuality = 3;
    public static bool IsFullScreen = true;
    //Players
    public static List<PlayerAtributes> PlayerAtributes = new List<PlayerAtributes>();


    public static bool ContainPlayer(PlayerAtributes player)
    {
        foreach(PlayerAtributes obj in PlayerAtributes)
        {
            if(obj.PlayerReference == player.PlayerReference)
            {
                return true;
            }
        }
        return false;
    }
    public static void SetPlayerAtributes(List<PlayerAtributes> playerAtributes)
    {
        PlayerAtributes.Clear();
        for (int i = 0; i < playerAtributes.Count; i++)
        {
            PlayerAtributes.Add(playerAtributes[i]);
        }
    }


    public static string DebugInformations()
    {

        string _numberOfPlayers = NumberOfPlayers.ToString();
        string _ambientSound = MusicVolume.ToString("0.00");
        string _fxSound = UIVolume.ToString("0.00");
        string _debug = "Informações de config --------->" +
                        "Numero de jogadores: " + _numberOfPlayers + ";  "
                         + "Volume do ambiente: " + _ambientSound + ";  "
                          + "Volume do Fx: " + _fxSound;
        return _debug;
    }
    public static string DebugPlayersInformations()
    {
        string playerAtribute = "Players Salvos: "+ PlayerAtributes.Count.ToString() + "---------> ";
        if (PlayerAtributes.Count > 0)
        {

            for (int i = 0; i < PlayerAtributes.Count; i++)
            {
                string _msg = PlayerAtributes[i].PlayerName + "; " + PlayerAtributes[i].Initiative + "; " + PlayerAtributes[i].PlayerReference.ToString()+" @@@ ";
                playerAtribute += _msg;
            }
        }
        return playerAtribute;
    }
}
