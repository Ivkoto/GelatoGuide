﻿namespace GelatoGuide.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int FullNameMaxLength = 40;

            public const int FullNameMinLength = 4;

            public const int UserNameMinLength = 2;

            public const int UserNameMaxLength = 20;

            public const int PasswordMinLength = 6;
            
            public const int PasswordMaxLength = 100;
        }

        public class Place
        {
            public const int NameMinLength = 2;
        
            public const int NameMaxLength = 30;

            public const int DescriptionMinLength = 6;

            public const int MinSinceYear = 1800;

            public const int MaxSinceYear = 2100;
        }

        public class Articles
        {
            public const int TitleMinLength = 2;

            public const int SubTitleMinLength = 2;

            public const int TextMinLength = 20;

            public const int PostedByNameMinLength = 2;

            public const int SourceNameMinLength = 2;
        }
    }
}