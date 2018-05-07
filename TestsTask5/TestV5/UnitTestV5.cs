using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsTask5.TestV5
{
    [TestClass]
    public class UnitTestsV5
    {
        private const string TestDataDir = "TestV5\\TestData";
		
        private TestContext _contextInstance;
        public TestContext TestContext { get => _contextInstance; set => _contextInstance = value; }
		
        [DataSource(
             "Microsoft.VisualStudio.TestTools.DataSource.CSV",
             "|DataDirectory|\\" + TestDataDir + "\\CountSpacesData.csv",
             "CountSpacesData#csv",
             DataAccessMethod.Sequential),
         DeploymentItem(TestDataDir + "\\CountSpacesData.csv")]
        [TestMethod]
        public void TaskV5TestCountTheLargestSpacesAmount()
        {
            var charSequence = TestContext.DataRow["charSequence"].ToString();
            var actual = TaskV5.TaskV5.TaskV5.CountTheLargestSpacesAmount(TaskV5.TaskV5.TaskV5.StringToList(charSequence));
            var expected = uint.Parse(TestContext.DataRow["expected"].ToString());
            Assert.AreEqual(actual, expected);
        }
		
        [DataSource(
             "Microsoft.VisualStudio.TestTools.DataSource.CSV",
             "|DataDirectory|\\" + TestDataDir + "\\RemoveDuplicateSpacesData.csv",
             "RemoveDuplicateSpacesData#csv",
             DataAccessMethod.Sequential),
         DeploymentItem(TestDataDir + "\\RemoveDuplicateSpacesData.csv")]
        [TestMethod]
        public void TaskV5TestRemoveDuplicateSpaces()
        {
            var charSequence = TestContext.DataRow["charSequence"].ToString();
            var charList = TaskV5.TaskV5.TaskV5.StringToList(charSequence);
            var actual = TaskV5.TaskV5.TaskV5.RemoveDuplicateSpaces(charList);
            var expected = TaskV5.TaskV5.TaskV5.StringToList(TestContext.DataRow["expected"].ToString());
            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }
    }
}
