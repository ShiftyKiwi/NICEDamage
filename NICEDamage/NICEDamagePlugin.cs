using Dalamud.Interface.Windowing;
using Dalamud.Game.Gui.FlyText;
using Dalamud.Game.Text.SeStringHandling;
using System;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace NICEDamage
{
    public sealed class NICEDamagePlugin : IDalamudPlugin
    {
        public string Name => "NICE Damage Flyouts";

        private readonly IFlyTextGui flyTextGui;
        private readonly WindowSystem windowSystem = new("NICEDamage");

        public NICEDamagePlugin(IFlyTextGui flyTextGui)
        {
            this.flyTextGui = flyTextGui;
            this.flyTextGui.FlyTextCreated += this.OnFlyTextCreated;
        }

        private void OnFlyTextCreated(ref FlyTextKind kind, ref int val1, ref int val2, ref SeString text1, ref SeString text2, ref uint color, ref uint icon, ref uint damageTypeIcon, ref float yOffset, ref bool handled)
        {
            switch (kind)
            {
                case FlyTextKind.Dodge:
                case FlyTextKind.Incapacitated:
                case FlyTextKind.Interrupted:
                case FlyTextKind.Invulnerable:
                case FlyTextKind.Miss:
                case FlyTextKind.NamedDodge:
                case FlyTextKind.NamedMiss:
                case FlyTextKind.Reflect:
                case FlyTextKind.Reflected:
                case FlyTextKind.Resist:
                    break;
                default:
                    var amount = Math.Abs((long)val1);
                    if (amount % 100000 == 42069)
                    {
                        text2.Append(" OMGOMGOMG NICE DUDE NIIIIIICE ");
                    }
                    else if (amount % 100 == 69)
                    {
                        text2.Append(" NICE ");
                    }

                    break;
            }
        }

        public void Dispose()
        {
            this.flyTextGui.FlyTextCreated -= this.OnFlyTextCreated;
            this.windowSystem.RemoveAllWindows();
        }
    }
}
