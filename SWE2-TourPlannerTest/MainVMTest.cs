using NUnit.Framework;
using SWE2_TourPlanner.ViewModels;

namespace SWE2_TourPlannerTest
{
    public class MainVMTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestData_ShouldContainInitialList()
        {
            // Arrange
            TourListVM tourListVM = new TourListVM();
            SearchBarVM searchBarVM = new SearchBarVM();
            //MainVM mainViewModel = new MainVM(tourListVM, searchBarVM);
            // Act
            int expected = 5;
            int actual = tourListVM.TourItems.Count;
            // Assert
            Assert.AreEqual(expected, actual, "List should contain 4 Tour!");
        }


        [Test]
        public void TestSearchCommand_Shouldfind()
        {
            // Arrange
            TourListVM tourListVM = new TourListVM();
            SearchBarVM searchBarVM = new SearchBarVM();
            //MainVM mainViewModel = new MainVM(tourListVM,searchBarVM);
            searchBarVM.SearchName = "wien";
            // Act
            searchBarVM.SearchCommand.Execute(null); // simulate search button click
            int expectedDataCount = 2;
            int currentDataCount = tourListVM.TourItems.Count;
            // Assert
            Assert.AreEqual(expectedDataCount, currentDataCount, "Two Tour finded");
        }

        [Test]
        public void TestClearCommand_ShouldClear()
        {
            // Arrange
            TourListVM tourListVM = new TourListVM();
            SearchBarVM searchBarVM = new SearchBarVM();
            //MainVM mainViewModel = new MainVM(tourListVM, searchBarVM);
            // Act
            searchBarVM.ClearCommand.Execute(null); // simulate clear button click
            int expectedDataCount = 5;
            int currentDataCount = tourListVM.TourItems.Count;
            // Assert
            Assert.AreEqual(expectedDataCount, currentDataCount, "5 Tour finded");
        }
    }
}