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
                StartTime = "2017-11-01T02:00:00" ,
                EndTime="2017-11-01T01:00:00", 
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
                Id="4" ,
                StartTime = "2017-11-01T00:00:00" ,
                EndTime="2017-11-01T01:00:00", 
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
                Id="4" ,
                StartTime = "2017-11-01T02:00:00" ,
                EndTime="2017-11-01T01:00:00", 
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
                Id="4" ,
                StartTime = "2017-11-01T02:00:00" ,
                EndTime="2017-11-01T01:00:00", 
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
                Id="4" ,
                StartTime = "2017-11-01T02:00:00" ,
                EndTime="2017-11-01T01:00:00", 
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
                Id="4" ,
                StartTime = "2017-11-01T02:00:00" ,
                EndTime="2017-11-01T01:00:00", 
                Summary ="jafarshow",
                Price ="30",
                SalonId="18"
                
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
                Id="4" ,
                StartTime = "2017-11-01T00:00:00" ,
                EndTime="2017-11-01T01:00:00", 
                Summary ="moretha",
                Title="woejfnerijnfwirjnfeirjfnerijfnerijfnerifjn",
                Price ="30",
                SalonId="18"

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
                Id="4" ,
                StartTime = "2017-11-01T00:00:00" ,
                EndTime="2017-11-01T01:00:00", 
                Summary ="jafarshow",
                Price ="120",
                SalonId="18"

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
                Id="4" ,
                StartTime = "2017-11-01T00:00:00" ,
                EndTime="2017-11-01T18:00:00", 
                Summary ="jafarsh//comparing diffrence between start and end with show timeow",
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
                Id="4" ,
                StartTime = "2017-11-01T00:00:00" ,
                EndTime="2017-11-01T00:15:00", 
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
