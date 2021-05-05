﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessExceptions
{
    public class AlreadyExistException : Exception
    {
        public string errorMessage;
        public AlreadyExistException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
