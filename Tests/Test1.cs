using InnoSport.Data;
using InnoSport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Views.Пользователь
{
    [TestClass]
    public class AvailableSectionsTests
    {
        [TestMethod]
        public void LoadSections_ShouldLoadSectionsFromDatabase()
        {
            // Arrange
            var mockDbContext = new Mock<AppDBContext>();
            var mockSections = new List<Section>
            {
                new Section { Id = 1, Name = "Футбол", Type = "Спорт", Description = "Тренировки по футболу" },
                new Section { Id = 2, Name = "Плавание", Type = "Спорт", Description = "Тренировки по плаванию" }
            }.AsQueryable();

            var mockDbSet = MockDbSet(mockSections);
            mockDbContext.Setup(db => db.Sections).Returns(mockDbSet.Object);

            var availableSections = new AvailableSections();

            // Act
            availableSections.LoadSections();

            // Assert
            Assert.IsNotNull(availableSections.Sections);
            Assert.AreEqual(2, availableSections.Sections.Count);
            Assert.IsTrue(availableSections.Sections.Any(s => s.Name == "Футбол"));
        }

        private Mock<DbSet<T>> MockDbSet<T>(IQueryable<T> data) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet;
        }
    }
}

