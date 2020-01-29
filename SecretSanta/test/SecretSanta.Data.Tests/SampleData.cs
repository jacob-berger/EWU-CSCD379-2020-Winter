using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Data.Tests
{
    public static class SampleData
    {
        public const string Robert = "Robert";
        public const string Bobson = "Bobson";
        public const string Robbob = "Robbob";

        public static User CreateRobert() => new User(Robert, Bobson);

        public const string Cheryl = "Cheryl";
        public const string Thompson = "Thompson";
        public const string Cherson = "Cherson";

        public static User CreateCheryl() => new User(Cheryl, Thompson);

        public const string Luke = "Luke";
        public const string Skywalker = "Skywalker";
        public const string Lusky = "Lusky";

        public static User CreateLuke() => new User(Luke, Skywalker);

        public const string Fi = "Fi";
        public const string Do = "Do";
        public const string Fido = "Fido";

        public static User CreateFido() => new User(Fi, Do);

        public const string Gameboy = "Gameboy";
        public const string GameboyUrl = "www.nintendo.com";
        public const string GameboyDescription = "A handheld gaming console";

        public static Gift CreateGameboy() => new Gift(Gameboy, GameboyUrl, GameboyDescription, CreateCheryl());

        public const string Xbox = "Xbox";
        public const string XboxUrl = "www.xbox.com";
        public const string XboxDescription = "A home gaming console";

        public static Gift CreateXbox() => new Gift(Xbox, XboxUrl, XboxDescription, CreateRobert());

        public const string People = "People";
        public static Group CreateGroup() => new Group(People);
    }
}
