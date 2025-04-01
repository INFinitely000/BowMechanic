using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RuntimeConsole
{
    public static class Commands
    {
        [Command("timescale", "Set a world time scale")]
        public static void SetTimeScale(float scale)
        {
            Time.timeScale = scale;
        }
        
        [Command("timescale", "Set a world time scale")]
        public static void SetTimeScale(int scale)
        {
            Time.timeScale = scale;
        }

        [Command("restart", "Reload a current scene")]
        public static void Reload()
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        }

        [Command("help", "Displays console commands and their descriptions")]
        public static void Help()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine();
            
            foreach (var command in Console.Commands)
            {
                foreach (var variant in command.Value)
                {
                    builder.Append("/");
                    builder.Append(command.Key);
                    builder.Append(" ");

                    foreach (var parameter in variant.parameters)
                        builder.Append("[" + parameter.Name +"] ");

                    builder.Append("- ");
                    builder.Append(variant.description);

                    builder.AppendLine();
                }
            }

            Debug.Log(builder);
        }
    }
}
