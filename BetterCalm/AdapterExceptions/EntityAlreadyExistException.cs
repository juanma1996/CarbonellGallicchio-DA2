﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterExceptions
{
    public class EntityAlreadyExistException : Exception
    {
        private string errorMessage;
        public EntityAlreadyExistException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}