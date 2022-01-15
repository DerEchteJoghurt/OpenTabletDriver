using OpenTabletDriver.Plugin.Tablet;
using OpenTabletDriver.Plugin;

namespace OpenTabletDriver.Configurations.Parsers.XP_Pen
{
    public class XP_Artist13Parser : IReportParser<IDeviceReport>
    {
        public IDeviceReport Parse(byte[] report)
        {
            if (report[0] == 0x07)
            {
                if (report[1] == 0xC0)
                    return new OutOfRangeReport(report);

                return new XP_PenPressureOffsetTabletReport(report);
            }
            else if (report[0] == 0x06)
            {
                return new XP_PenAuxReport(report, 1);
            }

            return new OutOfRangeReport(report);
        }
    }
}
