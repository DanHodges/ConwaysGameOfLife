using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class ConstructorBuildsArray
    {
        RealGameOfLife game = new RealGameOfLife(1);
        bool actual = game.cellStatus(0, 0);
    }
}
