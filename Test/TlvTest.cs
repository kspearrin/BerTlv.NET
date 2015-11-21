using System;
using System.Collections.Generic;
using System.Linq;
using BerTlv;
using Xunit;

namespace Test
{
    public class TlvTest
    {
        // Verify: http://www.emvlab.org/tlvutils/?data=6F1A840E315041592E5359532E4444463031A5088801025F2D02656E
        private string _emvHexTlv = "6F1A840E315041592E5359532E4444463031A5088801025F2D02656E";

        [Fact]
        [Trait("Build", "Run")]
        public void ParseEmvHexTest()
        {
            var tlvs = Tlv.ParseTlv(_emvHexTlv);

            AssertTlv(tlvs);
        }

        [Fact]
        [Trait("Build", "Run")]
        public void ParseEmvByteTest()
        {
            var emvBytes = Enumerable
                .Range(0, _emvHexTlv.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(_emvHexTlv.Substring(x, 2), 16))
                .ToArray();

            var tlvs = Tlv.ParseTlv(emvBytes);

            AssertTlv(tlvs);
        }

        private void AssertTlv(ICollection<Tlv> tlvs)
        {
            Assert.NotNull(tlvs);
            Assert.True(tlvs.Count == 1);

            var _6F = tlvs.SingleOrDefault(t => t.HexTag == "6F");
            Assert.NotNull(_6F);
            Assert.True(_6F.Children.Count == 2);

            var _6F84 = _6F.Children.SingleOrDefault(t => t.HexTag == "84");
            Assert.NotNull(_6F84);
            Assert.True(_6F84.Children.Count == 0);
            Assert.True(_6F84.HexValue == "315041592E5359532E4444463031");

            var _6FA5 = _6F.Children.SingleOrDefault(t => t.HexTag == "A5");
            Assert.NotNull(_6FA5);
            Assert.True(_6FA5.Children.Count == 2);

            var _6FA588 = _6FA5.Children.SingleOrDefault(t => t.HexTag == "88");
            Assert.NotNull(_6FA588);
            Assert.True(_6FA588.HexValue == "02");

            var _6FA55F2D = _6FA5.Children.SingleOrDefault(t => t.HexTag == "5F2D");
            Assert.NotNull(_6FA55F2D);
            Assert.True(_6FA55F2D.HexValue == "656E");
        }
    }
}
