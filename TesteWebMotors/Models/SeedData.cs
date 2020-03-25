using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteWebMotors.AppService;
using TesteWebMotors.Repository;

namespace TesteWebMotors.Models
{
    public class SeedData
    {
        public static void SeedDatabase(TesteWebMotorsContext context)
        {
            context.Database.Migrate();
        }
    }
}
