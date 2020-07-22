using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Core
{
    public interface IOrientationHandler
    {
        void ForceLandscape();
        void ForcePortrait();
    }
}
