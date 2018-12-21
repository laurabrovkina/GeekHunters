using System;
using Xunit;
using GeekHunter.Controllers;
using GeekHunter.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace GeekHunter.Tests
{
    public class UnitTest1
    {
    private GeekHunterContext GetContextWithData()
            {
                var context = new GeekHunterContext();
            
                var Skill1 = new Skill { Id = 1, Name = "Singer" };
                var Skill2 = new Skill { Id = 2, Name = "Dancer" };
                
                context.Skill.Add(Skill1);
                context.Skill.Add(Skill1);
            
                return context;
            }
 
    [Fact]
    public void Get_WhenCalled_ReturnsOkResult()
            {
            using (var context = GetContextWithData())
            {
                 var controller = new SkillsController(context);
           { 
                var okResult = controller.GetAll();
                Assert.NotNull(okResult);
            }
        }
        }
    }
}
