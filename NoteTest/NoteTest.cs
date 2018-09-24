using System;
using System.Linq;
using sample;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using w3.Controllers;
using Xunit;
using Moq;

namespace sample
{

public class NoteTest
{
    public List<mynotes> mockdatabase()
    {
        return new List<mynotes>
        {
            new mynotes
            {
                 id= 104,
                title= "relativity",
                text= "Time runs faster in space than earth due to relativity ",
                type = "science",
                favourite = true


            },
            new mynotes
            {
                id= 106,
                title= "calculas",
                text= "calculas is applied in many areas ",
                type= "math",
                favourite= true
            }


        };

    }

    [Fact]
    public void Getalldata_positive()
    {
        List<mynotes> temp = mockdatabase();  // Arrange
            
            Mock<irepo> MockRepository = new Mock<irepo>(); // Removing Dependency
            MockRepository.Setup(d => d.getalldata()).Returns(temp);
            
            ValuesController ValuesController = new ValuesController(MockRepository.Object); 
            var actual = ValuesController.Get();
            
            Assert.NotNull(actual); // Assert
            Assert.Equal(2 , temp.Count);
    
    }

    [Fact]
    public void get_id_positive()
    {
        List<mynotes> temp = mockdatabase();
            int id = 104;

            Mock<irepo> MockRepository = new Mock<irepo>();
            MockRepository.Setup(d => d.get_id(id)).Returns(temp.FirstOrDefault( d => d.id == id ));

            ValuesController ValuesController = new ValuesController(MockRepository.Object);
            var actual  = ValuesController.Get(id);

            var okObjectResult = actual as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as sample.mynotes;
            Assert.NotNull(model);

            Assert.Equal( temp.FirstOrDefault( d => d.id == id ).id , model.id);


    }

    [Fact]
    public void get_title_positive()
    {
        List<mynotes> temp = mockdatabase();
            string notetitle = "relativity";

            Mock<irepo> MockRepository = new Mock<irepo>();
            MockRepository.Setup(d => d.get_title(notetitle))
                            .Returns(temp.Where( d => d.title == notetitle ).ToList());

            ValuesController ValuesController = new ValuesController(MockRepository.Object);
            var actual  = ValuesController.Get(notetitle,"title");

            var okObjectResult = actual as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as List<mynotes>;
            Assert.NotNull(model);

           // Assert.Equal("relativity", temp.FirstOrDefault( d => d.title == notetitle ).title);
            foreach (var item in model)
            {
              Assert.Equal("relativity",item.title) ; 
            }
    
    }


    [Fact]
    public void get_type_positive()
    {
        List<mynotes> temp = mockdatabase();
            string notetype = "math";

            Mock<irepo> MockRepository = new Mock<irepo>();
            MockRepository.Setup(d => d.get_type(notetype))
                            .Returns(temp.Where( d => d.type == notetype ).ToList());

            ValuesController ValuesController = new ValuesController(MockRepository.Object);
            var actual  = ValuesController.Get(notetype,"type");

            var okObjectResult = actual as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as List<mynotes>;
            Assert.NotNull(model);

           // Assert.Equal("relativity", temp.FirstOrDefault( d => d.title == notetitle ).title);
            foreach (var item in model)
            {
              Assert.Equal("math",item.type) ; 
            }
    
    }



}


}