using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeflix.Models;

namespace CodeflixTests
{
    [TestClass]
    public class MediaItemTests
    {
        [TestMethod]
        public void Constructor_ShouldSetAllPropertiesCorrectly()
        {
            MediaItem item = new MediaItem(
                1,
                "Inception",
                "Sci-Fi",
                2010,
                "Movie",
                8.8,
                "Christopher Nolan"
            );

            Assert.AreEqual(1, item.Id);
            Assert.AreEqual("Inception", item.Title);
            Assert.AreEqual("Sci-Fi", item.Genre);
            Assert.AreEqual(2010, item.ReleaseYear);
            Assert.AreEqual("Movie", item.Type);
            Assert.AreEqual(8.8, item.Rating);
            Assert.AreEqual("Christopher Nolan", item.Director);
        }

        [TestMethod]
        public void ToString_ShouldReturnFormattedString()
        {
            MediaItem item = new MediaItem(
                2,
                "Dark",
                "Sci-Fi",
                2017,
                "TV Show",
                8.7,
                "Baran bo Odar"
            );

            string result = item.ToString();

            Assert.IsTrue(result.Contains("Dark"));
            Assert.IsTrue(result.Contains("Sci-Fi"));
            Assert.IsTrue(result.Contains("2017"));
            Assert.IsTrue(result.Contains("TV Show"));
        }
    }
}