﻿using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Core.Mock.Repository
{
    public class MockNoteRepos : INoteRepository
    {
        private List<Note> _notes = new List<Note>
        {
            new Note
            { 

            },

             new Note
            {

            }
        };
        
        public bool Add(Note item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> Get(Func<Note, bool> filter = null)
        {
            return _notes;
        }

        public Note GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Note item)
        {
            throw new NotImplementedException();
        }
    }
}