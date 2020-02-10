using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Controllers;
using SecretSanta.Business;
using SecretSanta.Business.Dto;
using SecretSanta.Data;
using System;

namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class GiftControllTests : BaseApiControllerTests<Business.Dto.Gift, GiftInput, Data.Gift>
    {
        protected override Business.Dto.Gift CreateDto()
        {
            throw new NotImplementedException();
        }

        protected override Data.Gift CreateEntity()
        {
            throw new NotImplementedException();
        }

        protected override GiftInput CreateInput()
        {
            throw new NotImplementedException();
        }
    }
}
