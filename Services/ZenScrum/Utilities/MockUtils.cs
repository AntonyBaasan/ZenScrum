﻿using Domain;

namespace ZenScrum.Utilities
{
    public class MockUtils
    {
        public static Project[] GetMockProjects()
        {
            return new Project[]
            {
                new Project {Id = 1, Name = "Project1", Details = "This is a first project", Moniker = "1nd"},
                new Project {Id = 2, Name = "Project2", Details = "This is a 2nd project", Moniker = "2nd"},
                new Project {Id = 3, Name = "Project3", Details = "This is a 3rd project", Moniker = "3rd"}
            };
        }
    }
}
