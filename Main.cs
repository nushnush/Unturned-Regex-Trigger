using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using SDG.Unturned;
using UnityEngine;

namespace RegexTrigger
{
    class Main : RocketPlugin<Configuration>
    {
        public static Main instance { private set; get; }
        protected override void Load()
        {
            instance = this;
            UnturnedPlayerEvents.OnPlayerChatted += PlayerChatted;
        }

        protected override void Unload()
        {
            instance = null;
            UnturnedPlayerEvents.OnPlayerChatted -= PlayerChatted;
        }

        private void PlayerChatted(UnturnedPlayer player, ref Color color, string message, EChatMode chatMode, ref bool cancel)
        {
            List<string> regexes = Configuration.Instance.regexes;
            Regex r;

            for (int i = 0; i < regexes.Count; i++)
            {
                r = new Regex(regexes[i], RegexOptions.IgnoreCase);
                var matches = r.Matches(@"" + message);

                if (matches != null && matches.Count > 0)
                {
                    UnturnedChat.Say(player, $"Never use disrespectful words in the chat ({matches[0].Value}).", Color.red);
                    cancel = true;
                    break;
                }
            }
        }
    }
}
