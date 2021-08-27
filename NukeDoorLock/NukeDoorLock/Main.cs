using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace NukeDoorLock
{
    public class Main : Plugin<Config>
    {
        EventHandlers EventHandler = new EventHandlers();

        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandler = new EventHandlers();
            Player.InteractingDoor += EventHandler.InteractingDoor;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            EventHandler = new EventHandlers();
            Player.InteractingDoor -= EventHandler.InteractingDoor;
        }
    }
}
