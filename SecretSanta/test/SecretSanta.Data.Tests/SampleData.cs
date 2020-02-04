using SecretSanta.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Data.Tests
{
    public static class SampleData
    {
        public const string SwitchTitle = "Switch";
        public const string SwitchUrl = "www.nintendo.com/switch/";
        public const string SwitchDescription = "The newest portable handheld gaming console";
        public static Gift CreateSwitchGift() => new Gift(SwitchTitle, SwitchUrl, SwitchDescription, CreateUserSoap());

        public const string N64Title = "N64";
        public const string N64Url = "www.nintendo.com/consumer/systems/nintendo64/index.jsp";
        public const string N64Description = "The first 3D console from Nintendo";
        public static Gift CreateN64Gift() => new Gift(N64Title, N64Url, N64Description, CreateUserRoach());

        public const string New3DsTitle = "New3DS";
        public const string New3DsUrl = "www.nintendo.com/3ds/";
        public const string New3DsDescription = "The first 3D stereoscopic handheld from Nintendo";
        public static Gift CreateNew3DsGift() => new Gift(New3DsTitle, New3DsUrl, New3DsDescription, CreateUserReznov());

        public const string Soap = "Soap";
        public const string McTavish = "McTavish";
        public static User CreateUserSoap() => new User(Soap, McTavish);

        public const string Gary = "Gary";
        public const string Sanderson = "Sanderson";
        public static User CreateUserRoach() => new User(Gary, Sanderson);

        public const string Viktor = "Viktor";
        public const string Reznov = "Reznov";
        public static User CreateUserReznov() => new User(Viktor, Reznov);

        public const string AmericanGroupTitle = "American";
        public static Group CreateAmericanGroup() => new Group(AmericanGroupTitle);

        public const string RussianGroupTitle = "Russian";
        public static Group CreateRussianGroup() => new Group(RussianGroupTitle);
    }
}
