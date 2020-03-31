using BlabberApp.Domain.Interfaces;
using System;

namespace BlabberApp.Domain.Entities
{
    public class Blab : IEntity
    {
        public Guid Id{get;set;}
        public DateTime DTTM {get;}
        public string Message {get; set;}
        public User User{get;set;}

        public Blab()
        {
            this.User = new User();
            this.Message = "";
        }

        public Blab(string Message)
        {
            this.User = new User();
            this.Message = Message;
        }

        public Blab(User user)
        {
            this.User = user;
            this.Message = "";
        }

        public bool IsValid()
        {
            //Validation code still needed
            return true;
        }
    }
}