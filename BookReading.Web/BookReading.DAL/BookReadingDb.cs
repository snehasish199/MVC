using BookReading.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookReading.DAL

{
    public class BookReadingDb : DbContext
    {
        //public DbSet<BookEvent> BookEvents { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<InvitedUser> InvitedUsers { get; set; }

        //public DbSet<UserRole> UserRoles { get; set; }
        public  DbSet<BookEvent> BookEvents { get ; set ; }
        public DbSet<User> Users { get ; set ; }
        public DbSet<InvitedUser> InvitedUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set ; }
    }
}
