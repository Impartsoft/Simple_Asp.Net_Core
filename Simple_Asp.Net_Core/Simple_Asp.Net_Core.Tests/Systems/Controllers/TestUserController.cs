using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Controllers;
using Simple_Asp.Net_Core.Data;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Tests.Systems.Controllers;

public class TestUserController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        var sut = new UserController();

        var result = (OkObjectResult)await sut.Get();

        result.StatusCode.Should().Be(200);
    }

    public void Test2()
    {

        ThreadPool.QueueUserWorkItem(async (x) =>
        {
            await File.WriteAllTextAsync(@"E:\A.txt", "XX");
            Console.WriteLine("xx");
        });
    }

    public async Task<double> GetDouble()
    {
        return await Task.Run(() => { return 1.1; });
    }

    public  Task<double> GetDouble2()
    {
        return Task.FromResult(3.0);
    }
}