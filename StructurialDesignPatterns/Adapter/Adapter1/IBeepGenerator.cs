using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Adapter1
{
    internal interface IBeepGenerator
    {
        void EnhancedBeep(in double duration);
    }
}
