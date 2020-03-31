﻿using System;
using System.Collections;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlabberApp.DataStore.Interfaces;


namespace BlabberApp.DataStore.Plugins
{
    public class InMemory : IPlugin
    {

        private ArrayList buffer;

        public InMemory()
        {
            this.buffer = new ArrayList();
        }

        public void Create(IEntity obj)
        {
            this.buffer.Add(obj);
        }

        public IEnumerable ReadAll()
        {
            return this.buffer;
        }

        public IEntity ReadById(Guid Id)
        {
            foreach(IEntity obj in this.buffer)
            {
                if (Id.Equals(obj.Id))
                {
                    return obj;
                }
            }
            return null;
        }

        public void Update(IEntity obj)
        {
            this.Delete(obj);
            this.Create(obj);
        }

        public void Delete(IEntity obj)
        {
            this.buffer.Remove(obj);
        }
    }
}