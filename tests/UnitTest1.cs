using System.Runtime.Serialization;
using System;
using Xunit;
using RA;

namespace tests
{
    public class UnitTest1
    {
        [Fact]
        public void RepetitiousIdTest()
        {
            var body = new{
                Id="1" ,
                Title="sahdf",
                StartTime = "2020-11-03T00:00:00" ,
                EndTime="2020-11-03T01:00:00", 
                Summary ="jafarshow",
                Price ="30",
                SalonId="1"
            };
            new RestAssured()
            .Given()
                .Name(" repetitious id test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("repetitious id test", b =>  b == 409)
                .AssertAll();
        }
        [Fact]

        public void ConflictShowTimeTest()
        {
            var body = new{
                Id="7" ,
                Title="sahdf",
                StartTime = "2020-11-01T00:00:00" ,
                EndTime="2020-11-01T01:00:00", 
                Summary ="jafarshow",
                Price ="30",
                SalonId="1"
            };
            new RestAssured()
            .Given()
                .Name("conflict time test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("conflict time test", b =>  b == 409)
                .AssertAll();

        }
        
        [Fact]

        public void StartTimeGreatarThanEndTimeTest()
        {
            var body = new{
                Id="7" ,
                Title="sahdf",
                StartTime = "2020-11-04T02:00:00" ,
                EndTime="2020-11-04T01:00:00", 
                Summary ="jafarshow",
                Price ="30",
                SalonId="1"
                
            };
            new RestAssured()
            .Given()
                .Name("time test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("time test", b =>  b == 400)
                .AssertAll();
        }//passed

        [Fact]
        public void NegativePricePost()
        {
             var body = new{
                Id="7" ,
                Title="sahdf",
                StartTime = "2020-11-05T00:00:00" ,
                EndTime="2020-11-05T01:00:00", 
                Summary ="jafarshow",
                Price ="-45",
                SalonId="1"
                
            };
            new RestAssured()
            .Given()
                .Name("negative price  test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("negative price test", b =>  b == 400)
                .AssertAll();

        }
        [Fact]
        public void StartTimeTest()
        {
            var body = new{
                Id="7" ,
                Title="sahdf",
                StartTime = "2020-11-06T02:00:00" ,
                EndTime="2020-11-06T01:00:00", 
                Summary ="jafarshow",
                Price ="30",
                SalonId="1"
                
            };
            new RestAssured()
            .Given()
                .Name("negative price  test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("negative price test", b =>  b == 400)
                .AssertAll();
        }
        [Fact]

        public void SalonIdIsNotAvailableTest()
        {
            var body = new{
                Id="7" ,
                Title="sahdf",
                StartTime = "2020-11-07T00:00:00" ,
                EndTime="2020-11-07T01:00:00", 
                Summary ="jafarshow",
                Price ="30",
                SalonId="210"
                
            };
            new RestAssured()
            .Given()
                .Name("negative price  test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("negative price test", b =>  b == 400)
                .AssertAll();
        }
        [Fact]

        public void TitleCharacterTest()
        {
            var body =new{
                Id="7" ,
                StartTime = "2020-11-08T00:00:00" ,
                EndTime="2020-11-08T01:00:00", 
                Summary ="moretha",
                Title="woejfnerijnfwirjnfeirjfnerijfnerijfnerifjn",
                Price ="30",
                SalonId="1"

            };
            new RestAssured()
            .Given()
                .Name("negative price  test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("negative price test", b =>  b == 400)
                .AssertAll();
        }
        [Fact]

        public void PriceCeilingTest()
        {
            var body =new{
                Id="7" ,
                Title="sahdf",
                StartTime = "2020-11-09T00:00:00" ,
                EndTime="2020-11-09T01:00:00", 
                Summary ="jafarshow",
                Price ="120",
                SalonId="1"

            };
            new RestAssured()
            .Given()
                .Name("negative price  test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("negative price test", b =>  b == 400)
                .AssertAll();
        }

        [Fact]
        
        public void MinimumShowTimeTest()
        {
            var body =new{
                Id="7",
                Title="sahdf",
                StartTime = "2020-11-10T00:00:00" ,
                EndTime="2020-11-10T00:15:00", 
                Summary ="jafarsh",
                Price ="120",
                SalonId="1"

            };
            new RestAssured()
            .Given()
                .Name("show time  test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("show time test", b =>  b == 400)
                .AssertAll();
        }

        [Fact]
        public void MaximumShowTimeTest()
        {
             var body =new{
                Id="7" ,
                Title="sahdf",
                StartTime = "2020-11-01T00:00:00" ,
                EndTime="2020-11-01T17:00:00", 
                Summary ="jafarshow",
                Price ="120",
                SalonId="1"

            };
            new RestAssured()
            .Given()
                .Name("show time  test")
                .Header("Content-Type","application/json")
                .Header("Accept-Encoding","utf-8")
                .Body(body)
            .When()
                .Post("http://localhost:5000/shows")
                .Then()
                .TestStatus("show time test", b =>  b == 400)
                .AssertAll();
        }

    }
}
