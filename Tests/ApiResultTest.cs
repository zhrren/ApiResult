using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mark.ApiResult;

namespace Tests
{
    public class Model
    {
        public string Name { get; set; }
    }

    [TestClass]
    public class ApiResultTest
    {
        [TestMethod]
        public void ConvertTest()
        {
            ApiResult result = ApiResult.Success<Model>(new Model() { Name = "Book" }, "200");
            ApiResult<Model> modelResult = (ApiResult<Model>)result;

            Assert.AreEqual("Book", modelResult.Data.Name);
        }
    }
}
