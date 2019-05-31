using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectTask.Models
{
    public class TasksDbSeeder
    {

        public static void Initialize(TasksDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any tasks.
            if (context.Tasks.Any())
            {
                return;   // DB has been seeded
            }

            context.Tasks.AddRange(
                new Task
                {
                    Title ="Sleep",
                    Description ="Rest",
                    Added = DateTime.Now,
                    Deadline = DateTime.Now.AddDays(35),
                    Important = Task.Importance.High,
                    State = Task.Stare.InProgress,
                    CloseAt = DateTime.Now.AddDays(35)

                },
                new Task
                {
                    Title = "Eat",
                    Description = "Eat",
                    Added = DateTime.Now,
                    Deadline = DateTime.Now.AddDays(14),
                    Important = Task.Importance.Low,
                    State = Task.Stare.Open,
                    CloseAt = DateTime.Now.AddDays(14)

                },
                new Task
                {
                  Title = "Read",
                  Description = "Read",
                  Added = DateTime.Now,
                  Deadline = DateTime.Now.AddDays(20),
                  Important = Task.Importance.Low,
                  State = Task.Stare.Open,
                  CloseAt = DateTime.Now.AddDays(20)
                },
                new Task
                {
                  Title = "Run",
                  Description = "Run",
                  Added = DateTime.Now,
                  Deadline = DateTime.Now.AddDays(24),
                  Important = Task.Importance.Low,
                  State = Task.Stare.Open,
                  CloseAt = DateTime.Now.AddDays(25)
                },
                new Task
                {
                  Title = "Study",
                  Description = "Study",
                  Added = DateTime.Now,
                  Deadline = DateTime.Now.AddDays(14),
                  Important = Task.Importance.Low,
                  State = Task.Stare.Open,
                  CloseAt = DateTime.Now.AddDays(14)
                },
                new Task
                {
                  Title = "Research",
                  Description = "Research",
                  Added = DateTime.Now,
                  Deadline = DateTime.Now.AddDays(30),
                  Important = Task.Importance.Low,
                  State = Task.Stare.Open,
                  CloseAt = DateTime.Now.AddDays(32)
                }
            );
            context.SaveChanges();
        }
    }
}

