using System.ComponentModel;

namespace Lottery.Data.Model
{
    public enum RuffledType
    {
        [Description("Award that can be won once the code is send")]
        Immediate = 0,
        [Description("Award that can be won at the end of the day ruffled")]
        PerDay = 1,
        [Description("Award that can be won at the final ruffled")]
        Final = 2
    }
}
