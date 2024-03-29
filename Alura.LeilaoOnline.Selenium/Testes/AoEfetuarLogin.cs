﻿using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture) => driver = fixture.Driver;


        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashBoard()
        {
            //arrange
            var loginPo = new LoginPO(driver);
            loginPo.Visitar();
            loginPo.PreencheFormulario("fulano@example.org", "123");


            //act
            loginPo.SubmeteFormulario();


            //assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void DadoCredenciaisInValidasDeveNontinuar()
        {
            //arrange
            var loginPo = new LoginPO(driver);
            loginPo.Visitar();
            loginPo.PreencheFormulario("fulano@eas.org", "125453");


            //act
            loginPo.SubmeteFormulario();


            //assert
            Assert.Contains("Login", driver.PageSource);
        }


    }
}
