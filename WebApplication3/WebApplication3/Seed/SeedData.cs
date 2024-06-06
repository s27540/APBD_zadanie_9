﻿using Microsoft.EntityFrameworkCore;
using WebApplication3.DbContext;
using WebApplication3.Models;

namespace WebApplication3.Seed;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context.Doctors.Any() || context.Patients.Any())
            {
                return; 
            }

            context.Doctors.AddRange(
                new Doctor
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com"
                },
                new Doctor
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com"
                }
            );

            context.Patients.AddRange(
                new Patient
                {
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Birthdate = new DateTime(1990, 1, 1)
                },
                new Patient
                {
                    FirstName = "Bob",
                    LastName = "Brown",
                    Birthdate = new DateTime(1985, 2, 20)
                }
            );

            context.Medicaments.AddRange(
                new Medicament
                {
                    Name = "Medicament1",
                    Description = "Description1",
                    Type = "Type1"
                },
                new Medicament
                {
                    Name = "Medicament2",
                    Description = "Description2",
                    Type = "Type2"
                }
            );

            context.SaveChanges();
        }
    }
}
