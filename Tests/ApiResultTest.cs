using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Mark.ApiResult;

namespace Tests
{
    public class Model
    {
        public string Name { get; set; }
    }

    public class ApiResultTest
    {
        [Fact]
        public void ConvertTest()
        {
            ApiResult result = new ApiResult<Model>();
            ApiResult<Model> modelResult = (ApiResult<Model>)result;
        }
    }
}
