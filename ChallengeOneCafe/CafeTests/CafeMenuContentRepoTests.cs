using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeLibrary;

namespace CafeTests
{
    [TestClass]
    public class CafeMenuContentRepoTests
    {
        private CafeMenuContent _content;
        private CafeMenuRepository _repo;

        [TestInitialize] 
        public void Arrange()
        {
            List<string> hotdogIngredients = new List<string>() {"all beef wiener", "bun", "castup", "mustard"};
            _content = new CafeMenuContent(1, "Hotdog", "A very standard hotdog", hotdogIngredients, 3.99m);
            _repo = new CafeMenuRepository();

            _repo.AddContentToRepository(_content);

        }

        [TestMethod]
        public void TestAddToRepo_ShouldGetTrue()
        {
            // arrange
            CafeMenuContent content = new CafeMenuContent();
            CafeMenuRepository repo = new CafeMenuRepository();
            // act
            bool result = repo.AddContentToRepository(content);
            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetAllContent_ShouldReturnCorrectList()
        {
            // arrange
            CafeMenuContent content = new CafeMenuContent();
            CafeMenuRepository repo = new CafeMenuRepository();
            CafeMenuContent book = new CafeMenuContent();
            repo.AddContentToRepository(content);
            repo.AddContentToRepository(book);

            // act
            List<CafeMenuContent> result = repo.GetContents();

            // assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(book));
        }

        [TestMethod]
        public void GetContentByName_ShouldReturnCorrectContent()
        {
            // arrange
            // CafeMenuContent content = new CafeMenuContent();
            // CafeMenuContent jaws = new CafeMenuContent("Jaws", "shark movie", 7.8, MaturityRating.PG_13, 99);
            // CafeMenuRepository repo = new CafeMenuRepository();
            // content.Title = "";
            // repo.AddContentToRepository(content);
            // repo.AddContentToRepository(jaws);

            // act
            CafeMenuContent result = _repo.GetContentByName("Hotdog");

            // assert
            Assert.AreEqual("A very standard hotdog", result.Description);
        }

        [TestMethod]
        public void UpdateContent_ShouldUpdateContent()
        {
            // arrange
                // this was handled by the TestInitialize
            List<string> burgerIngredients = new List<string>() {"patty", "bun", "cheese"};
            CafeMenuContent content = new CafeMenuContent (2, "Cheeburger", "A very cheesy burger", burgerIngredients, 3.99m);
            
            // act
            bool result = _repo.UpdateExistingContent(_content.Name, content);

            // assert
            Assert.IsTrue(result);

                // alternate assertion option
                List<CafeMenuContent> resultList = _repo.GetContents();

                Assert.IsFalse(resultList.Contains(_content));

        }

        [TestMethod]
        public void DeleteContent_ShouldRemoveContent()
        {
            // arrange
                // this was handled by the TestInitialize
            
            // act
            bool result = _repo.DeleteExistingContent(_content);

            // assert
            Assert.IsTrue(result);

                // alternate assertion option
                List<CafeMenuContent> resultList = _repo.GetContents();

                Assert.IsFalse(resultList.Contains(_content));

        }
    }
}