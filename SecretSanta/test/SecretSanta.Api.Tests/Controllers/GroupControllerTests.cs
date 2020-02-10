using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Controllers;
using SecretSanta.Business;
using SecretSanta.Business.Dto;
using SecretSanta.Data;
using System;

namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class GroupControllerTests : BaseApiControllerTests<Business.Dto.Group, GroupInput, Data.Group>
    {
        protected override Business.Dto.Group CreateDto()
        {
            throw new NotImplementedException();
        }

        protected override Data.Group CreateEntity()
        {
            throw new NotImplementedException();
        }

        protected override GroupInput CreateInput()
        {
            throw new NotImplementedException();
        }
    }
}
