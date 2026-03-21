using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeflix.DataStructures;
using Codeflix.Models;
using System.Collections.Generic;

namespace CodeflixTests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        private BinarySearchTree tree;

        [TestInitialize]
        public void Setup()
        {
            tree = new BinarySearchTree();

            tree.Insert(new MediaItem(1, "Inception", "Sci-Fi", 2010, "Movie", 8.8, "Christopher Nolan"));
            tree.Insert(new MediaItem(2, "Dark", "Sci-Fi", 2017, "TV Show", 8.7, "Baran bo Odar"));
            tree.Insert(new MediaItem(3, "Breaking Bad", "Crime", 2008, "TV Show", 9.5, "Vince Gilligan"));
            tree.Insert(new MediaItem(4, "The Matrix", "Sci-Fi", 1999, "Movie", 8.7, "Wachowski Sisters"));
        }

        [TestMethod]
        public void Insert_ShouldAddNewItem()
        {
            MediaItem newItem = new MediaItem(5, "Dune", "Sci-Fi", 2021, "Movie", 8.0, "Denis Villeneuve");

            bool inserted = tree.Insert(newItem);
            MediaItem found = tree.Search("Dune");

            Assert.IsTrue(inserted);
            Assert.IsNotNull(found);
            Assert.AreEqual("Dune", found.Title);
        }

        [TestMethod]
        public void Insert_ShouldRejectDuplicateTitle()
        {
            MediaItem duplicate = new MediaItem(6, "Inception", "Sci-Fi", 2010, "Movie", 8.8, "Christopher Nolan");

            bool inserted = tree.Insert(duplicate);

            Assert.IsFalse(inserted);
        }

        [TestMethod]
        public void Search_ShouldReturnCorrectItem_WhenTitleExists()
        {
            MediaItem found = tree.Search("Inception");

            Assert.IsNotNull(found);
            Assert.AreEqual("Inception", found.Title);
            Assert.AreEqual("Movie", found.Type);
        }

        [TestMethod]
        public void Search_ShouldReturnNull_WhenTitleDoesNotExist()
        {
            MediaItem found = tree.Search("Nonexistent Title");

            Assert.IsNull(found);
        }

        [TestMethod]
        public void Delete_ShouldRemoveExistingItem()
        {
            bool deleted = tree.Delete("Dark");
            MediaItem found = tree.Search("Dark");

            Assert.IsTrue(deleted);
            Assert.IsNull(found);
        }

        [TestMethod]
        public void Delete_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            bool deleted = tree.Delete("Unknown");

            Assert.IsFalse(deleted);
        }

        [TestMethod]
        public void GetAllItems_ShouldReturnItemsInSortedOrder()
        {
            List<MediaItem> items = tree.GetAllItems();

            Assert.AreEqual(4, items.Count);
            Assert.AreEqual("Breaking Bad", items[0].Title);
            Assert.AreEqual("Dark", items[1].Title);
            Assert.AreEqual("Inception", items[2].Title);
            Assert.AreEqual("The Matrix", items[3].Title);
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllItems()
        {
            tree.Clear();

            List<MediaItem> items = tree.GetAllItems();

            Assert.AreEqual(0, items.Count);
        }
    }
}