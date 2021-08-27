using Exiled.API.Enums;
using Exiled.Events.EventArgs;

namespace NukeDoorLock
{
    class EventHandlers
    {
        public void InteractingDoor(InteractingDoorEventArgs ev)
        {
            if (ev.Door.Type == DoorType.NukeSurface)
            {
                ev.Door.DoorLockType = DoorLockType.AdminCommand;
            }
        }
    }
}
