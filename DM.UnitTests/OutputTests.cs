using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DM.Core;

namespace DM.UnitTests
{
    [TestClass]
    public class OutputTests
    {
        IBoardRepository br;

        [TestInitialize]
        public void Setup()
        {
            br = new BoardRepository();
        }

        [TestMethod]
        public void ConvertBoardToPlate()
        {

        }
    }
}
