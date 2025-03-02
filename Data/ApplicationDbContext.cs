using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data {
    public class Entity : DbContext{
        public Entity(){}
        public Entity(DbContextOptions options):base(options){}
        public DbSet<ToDoTask>ToDoTasks{get; set;}
    }
}