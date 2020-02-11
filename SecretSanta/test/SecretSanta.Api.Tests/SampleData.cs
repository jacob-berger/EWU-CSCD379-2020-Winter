using SecretSanta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Api.Tests
{
    public static class SampleData
    {
        public const string Inigo = "Inigo";
        public const string Montoya = "Montoya";

        public static User CreateInigoMontoya() => new User(Inigo, Montoya);

        public const string Princess = "Princess";
        public const string Buttercup = "Buttercup";

        public static User CreatePrincessButtercup() => new User(Princess, Buttercup);

        public const string GameboyTitle = "Gameboy";
        public const string GameboyDescription = "Handheld game console";
        public const string GameboyUrl = "nintendo.com";

        public static Gift CreateGameboy() => new Gift(GameboyTitle, GameboyUrl, GameboyDescription, CreateInigoMontoya());
    }
}